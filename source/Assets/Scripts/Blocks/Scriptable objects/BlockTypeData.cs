using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "MoleDigger/Block Type")]


public class BlockTypeData : ScriptableObject
{
    [Header("Main parameters")]
    [SerializeField] private string _blockName;
    [SerializeField] private float _maxHp = 3;
    [SerializeField] private float _minDamage = 0;
    [SerializeField] private CellType type = CellType.Empty;
    [SerializeField] private Color _color = Color.white;

    [Header("Drop")]
    [SerializeField] private List<DropChance> _dropTable = new();

    [Header("Visual variety")]
    public Sprite[] possibleSprites;
    public bool randomSprite = true;
    [SerializeField] List<Sprite> _hittedSprites;
    public int ChosenSprite;

    #region Getters
    public string Name => _blockName;
    public float MaxHp => _maxHp;
    public float MinDamage => _minDamage;
    public CellType Type => type;
    public List<DropChance> GetDropTable => _dropTable;
    public Color Color => _color;
    public List<Sprite> HittedSprites => _hittedSprites;

    #endregion

    #region Block behabiour test configurators

    public void ConfigureForUnsuccessfulDamageTest()
    {
        _maxHp = 100;
        _minDamage = 50;
    }

    public void ConfigureForDropTest()
    {
        _maxHp = 1;
        _minDamage = 0;
        _dropTable.Add(new DropChance(ItemType.Stick, 1f));
        _dropTable.Add(new DropChance(ItemType.Rock, 1f));
        _dropTable.Add(new DropChance(ItemType.Pebbles, 1f));
    }

    #endregion
}