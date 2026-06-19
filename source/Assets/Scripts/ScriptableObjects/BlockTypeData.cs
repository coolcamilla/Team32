using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "MoleDigger/Block Type")]


public class BlockTypeData : ScriptableObject
{
    [Header("Main parameters")]
    [SerializeField] private string _blockName;
    [SerializeField] private float _maxHp;
    [SerializeField] private float _minDamage; 

    [Header("Drop")]
    [SerializeField] private List<DropChance> _dropTable = new();

    [Header("Visual variety")]
    public Sprite[] possibleSprites;
    public bool randomSprite = true;

    public string Name => _blockName;
    public float MaxHp => _maxHp;
    public float MinDamage => _minDamage;
    public List<DropChance> GetTable => _dropTable; 
}