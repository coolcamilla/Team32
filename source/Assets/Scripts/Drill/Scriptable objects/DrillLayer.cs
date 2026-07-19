using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "DrillLayer", menuName = "Scriptable Objects/DrillLayer")]
public class DrillLayer : ScriptableObject
{
    [SerializeField] private TileBase _foreground;
    [SerializeField] private TileBase _background;
    [SerializeField] private List<DropChance> _dropChances;
    [SerializeField] private float _dropFrequencyInMeters = 0.05f;
    [SerializeField] private float _durabilityModifier = 1f;
    [SerializeField] private float _maxDepth;
    [SerializeField] private int _requiredModulesLevel;

    public TileBase ForegroundTile => _foreground;
    public TileBase BackgroundTile => _background;
    public List<DropChance> DropChances => _dropChances;
    public float DurabilityModifier => _durabilityModifier;
    public float DropFrequencyInMeters => _dropFrequencyInMeters;
    public float MaxDepth => _maxDepth;
    public int RequiredModulesLevel => _requiredModulesLevel;
}
