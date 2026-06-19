using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private BlockTypeData _blockData;
    [SerializeField] private Animator _animator;

    private event UnityAction OnDamage;
    private System.Random _rand;
    private static Dictionary<CraftMaterial, GameObject> _materialToPrefab;
    private float _currentHp;
    private SpriteRenderer _spriteRenderer;

    public BlockTypeData BlockData => _blockData;

    private void Awake()
    {
        if (_blockData == null )
        {
            Debug.LogError($"Block {gameObject.name} doesnt have BlockTypeData");
            return;
        }

        _rand = new System.Random();
        _animator = GetComponent<Animator>();

        _materialToPrefab = MaterialToPrefab.GetDictionary;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _currentHp = _blockData.MaxHp;

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
        OnDamage += CheckHP;
    }

    private void OnDisable()
    {
        OnDamage -= PlayDamageAnimation;
        OnDamage -= UpdateSprite;
        OnDamage -= CheckHP;
    }

    public void SetSprite(Sprite sprite)
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = sprite;
        }
    }

public bool IsInstrumentSuitable(Instrument instrument)
    {
        return instrument.Damage >= _blockData.MinDamage;
    }

    public bool TryTakeDamage(Instrument instrument)
    {
        if (IsInstrumentSuitable(instrument))
        {
            TakeDamage(instrument);
            return true;
        }
        return false;
    }

    private void TakeDamage(Instrument instrument)
    {
        _currentHp -= instrument.Damage;
        OnDamage.Invoke();
    }

    private void UpdateSprite()
    {
        
    }

    private void CheckHP()
    {
        if (_currentHp <= 0)
        {
            DropLoot();
            Destroy(gameObject);
        }
    }

    private void DropLoot()
    {
        InventoryManager inventory = InventoryManager.GetInstance;
        foreach (var drop in _blockData.GetTable)
        {
            float dropChance = _rand.Next(100) / 100f;
            if (dropChance <= drop.Chance) Spawn(drop.GetMaterial);
        }
    }

    private void Spawn(CraftMaterial material)
    {
        Instantiate(_materialToPrefab[material], transform.position, Quaternion.identity);
    }

    private void PlayDamageAnimation()
    {
        _animator.SetBool("Damaged", true);
    }
}
