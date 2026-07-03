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
    [SerializeField] private float _blockOpenDuration;

    private event UnityAction OnDamage;
    
    private Animator _animator;
    private System.Random _rand;
    private SpriteRenderer _spriteRenderer;
    private Color _baseColor;

    private BlockBehaviourLogic _logic;

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

        _animator = GetComponent<Animator>();


        _spriteRenderer = GetComponent<SpriteRenderer>();
        _baseColor = _spriteRenderer.color;
        if (_blockData.Type != CellType.Grass) _spriteRenderer.color = Color.black;

        if (_blockData.randomSprite && _blockData.possibleSprites != null && _blockData.possibleSprites.Length > 0)
        {
            int randomIndex = _rand.Next(_blockData.possibleSprites.Length);
            _spriteRenderer.sprite = _blockData.possibleSprites[randomIndex];
        }
    }

    private void OnEnable()
    {
        OnDamage += PlayDamageAnimation;
        OnDamage += UpdateSprite;
    }

    private void OnDisable()
    {
        OnDamage -= PlayDamageAnimation;
        OnDamage -= UpdateSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenBlock();
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
        
    }

    public void OpenBlock()
    {
        StartCoroutine(ChangeColorCoroutine(_baseColor, _blockOpenDuration));
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
}
