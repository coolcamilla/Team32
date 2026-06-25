using System;
using UnityEngine;

[Serializable] public struct DropChance
{
    [SerializeField] private ItemType _material;
    [SerializeField][Range(0f, 1f)] private float _chance;

    public ItemType GetMaterial => _material;
    public float Chance => _chance;

    public DropChance(ItemType material, float chance)
    {
        _material = material;
        _chance = Mathf.Clamp01(chance);
    }
}
