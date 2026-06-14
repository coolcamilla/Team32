using System;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml.XPath;

public abstract class Instrument
{
    public float Damage { get; protected set; }
    public Sprite InstrumentSprite { get; protected set; }
    protected Dictionary<CraftMaterial, int> _resourcesToCraft;

    protected Instrument() 
    {
        _resourcesToCraft = new();
        AddCraftResources();
    }

    protected abstract void AddCraftResources();
    public bool IsCraftable()
    {
        bool result = true;
        InventoryManager inventory = InventoryManager.GetInstance;
        foreach (var pair in _resourcesToCraft)
        {
            result = inventory.IsEnough(pair.Key, pair.Value);
            if (!result) break;
        }

        return result;
    }

    public bool TryCraft()
    {
        if (!IsCraftable())
            return false;

        Craft();

        return true;
    }

    public void Craft()
    {
        if (!IsCraftable()) throw new System.Exception("Not enough resources!");

        InventoryManager inventory = InventoryManager.GetInstance;

        foreach (var pair in _resourcesToCraft)
        {
            inventory.TrySpendMaterial(pair.Key, pair.Value);
        }
    }

    public string GetCraftingString()
    {
        StringBuilder result = new StringBuilder();
        foreach (var pair in _resourcesToCraft)
        {
            result.Append(pair.Key.ToString());
            result.Append(": ");
            result.Append(pair.Value.ToString());
            result.Append("\n");
        }
        return result.ToString();
    }
}
