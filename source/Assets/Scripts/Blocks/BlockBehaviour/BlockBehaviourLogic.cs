using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class BlockBehaviourLogic
{
    private BlockTypeData _blockData;
    private System.Random _rand;
    private float _currentHp;

    public BlockTypeData BlockData => _blockData;
    public float CurrentHp => _currentHp;
    public BlockBehaviourLogic(BlockTypeData data)
    {
        _rand = new System.Random();
        _blockData = data;
        _currentHp = _blockData.MaxHp;
    }

    public bool TryTakeDamage(Item item)
    {
        if (IsItemSuitable(item))
        {
            TakeDamage(item);
            return true;
        }
        return false;
    }

    public bool IsItemSuitable(Item item)
    {
        return item.Damage >= _blockData.MinDamage;
    }

    private void TakeDamage(Item item)
    {
        _currentHp -= item.Damage;
    }

    public List<ItemType> CalculateDrops()
    {
        List<ItemType> result = new();
        foreach (var drop in _blockData.GetDropTable)
        {
            float dropChance = _rand.Next(100) / 100f;
            if (dropChance <= drop.Chance)
            {
                result.Add(drop.GetMaterial);
            }
        }
        return result;
    }

    public bool IsDestroyed()
    {
        return _currentHp <= 0;
    }
}
