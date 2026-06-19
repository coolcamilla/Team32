using System;
using UnityEngine;

[Serializable] public struct DropChance
{
    [SerializeField] private CraftMaterial _material;
    [SerializeField][Range(0f, 1f)] private float _chance;

    public CraftMaterial GetMaterial => _material;
    public float Chance => _chance;

    public DropChance(CraftMaterial material, float chance)
    {
        _material = material;
        _chance = Mathf.Clamp01(chance);
    }
}
