using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private BlockTypeData _blockData;
    [SerializeField] private float _blockToggleDuration;
    [SerializeField] private float _triggerRadiusScale = 2f;

    private event UnityAction OnDamage;

    private bool _isOpened;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _trigger;
    private Color _baseColor;
    private System.Random _rand;

    private GameObject _hitParticlesPrefab;
    private BlockBehaviourLogic _logic;
    private float _startTriggerRadius;

    public BlockTypeData BlockData => _blockData;

    private void Awake()
    {
        if (_blockData == null )
        {
            Debug.LogError($"Block {gameObject.name} doesnt have BlockTypeData");
            return;
        }

        _logic = new BlockBehaviourLogic(_blockData);
        _rand = new();
        _isOpened = false;

        _animator = GetComponent<Animator>();
        _trigger = GetComponent<CircleCollider2D>();
        _startTriggerRadius = _trigger.radius;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _baseColor = _spriteRenderer.color;
        if (_blockData.Type != CellType.Grass) _spriteRenderer.color = Color.black;

        if (_blockData.randomSprite && _blockData.possibleSprites != null && _blockData.possibleSprites.Length > 0)
        {
            int randomIndex = _rand.Next(_blockData.possibleSprites.Length);
            _spriteRenderer.sprite = _blockData.possibleSprites[randomIndex];
        }

        _hitParticlesPrefab = Resources.Load<GameObject>("Prefabs/Particles/HitParticles");
    }

    private void OnEnable()
    {
        OnDamage += PlayDamageAnimation;
        OnDamage += SpawnHitParticles;
        if (_blockData != null && _blockData.HittedSprites != null && _blockData.HittedSprites.Count > 0)
        {
            OnDamage += UpdateSprite;
        }
    }

    private void OnDisable()
    {
        OnDamage -= PlayDamageAnimation;
        OnDamage -= SpawnHitParticles;
        if (_blockData != null && _blockData.HittedSprites != null && _blockData.HittedSprites.Count > 0)
        {
            OnDamage -= UpdateSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isOpened && collision.CompareTag("Player"))
        {
            _trigger.radius = _startTriggerRadius * _triggerRadiusScale;
            OpenBlock();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isOpened && collision.CompareTag("Player") && !IsNaked())
        {
            _trigger.radius = _startTriggerRadius;
            CloseBlock();
        }
    }

    public void SetSprite(Sprite sprite)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = sprite;
        }
    }

    public void TryTakeDamage(Item item)
    {
        if (_logic.TryTakeDamage(item))
        {
            OnDamage.Invoke();
               
            if (_logic.IsDestroyed())
            {
                DropLoot();
                Destroy(gameObject);
            }
        }
    }

    private void UpdateSprite()
    {
        for (int i = 5; i > 0; i--)
        {
            if (_logic.CurrentHp <= _blockData.MaxHp * (6 - i) / 6.0f)
            {
                _spriteRenderer.sprite = _blockData.HittedSprites[i - 1];
                break;
            }
        }
    }

    public void OpenBlock()
    {
        StartCoroutine(ChangeColorCoroutine(_baseColor, _blockToggleDuration));
        _isOpened = true;
    }

    public void CloseBlock()
    {
        StartCoroutine(ChangeColorCoroutine(Color.black, _blockToggleDuration));
        _isOpened = false;
    }

    private IEnumerator ChangeColorCoroutine(Color targetColor, float duration)
    {
        Color startColor = _spriteRenderer.color;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            _spriteRenderer.color = Color.Lerp(startColor, targetColor, time / duration);

            yield return null;
        }
        _spriteRenderer.color = targetColor;
    }

    private void DropLoot()
    {
        List<ItemType> toDrop = _logic.CalculateDrops();

        foreach (var dropType in toDrop)
        {
            Spawn(dropType);
        }
    }

    private void Spawn(ItemType type)
    {
        Instantiate(TypeToPrefab.Convert(type), transform.position, Quaternion.identity);
    }

    private void PlayDamageAnimation()
    {
        _animator.SetBool("Damaged", true);
    }

    private void SpawnHitParticles()
    {
        if (_hitParticlesPrefab != null)
        {
            Vector3 spawnPos = transform.position + new Vector3(0, 0.2f, 0);
            GameObject particles = Instantiate(_hitParticlesPrefab, spawnPos, Quaternion.identity);
            
            var mainModule = particles.GetComponent<ParticleSystem>().main;
            mainModule.startColor = _blockData.Color;
        }
    }

    private bool IsNaked()
    {
        Transform transform = GetComponent<Transform>();

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), transform.right, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), transform.right * -1, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), transform.up, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), transform.up * -1, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(2, 2, 0), transform.right, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(-2, 2, 0), transform.right * -1, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(2, -2, 0), transform.up, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;

        hit = Physics2D.Raycast(transform.position + new Vector3(-2, -2, 0), transform.up * -1, 0.01f);
        if (hit.collider == null || !hit.collider.CompareTag("Block")) return true;
        return false;
    }
}
