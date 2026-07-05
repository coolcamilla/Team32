using System;
using System.Collections.Generic;
using UnityEngine;

public static class TypeToItemData
{
    private static Dictionary<ItemType, Item> _converter;

    public static Dictionary<ItemType, Item> Converter
    {
        get
        {
            if (_converter == null) InitializeDictionary();
            return _converter;
        }
    }

    public static Item Convert(ItemType type)
    {
        if (_converter == null)
        {
            InitializeDictionary();
        }
        return _converter[type];
    }

    private static void InitializeDictionary()
    {
        _converter = new Dictionary<ItemType, Item>();
        foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            if ((int) type < 100) continue;
            Item newItem = Resources.Load<Item>($"Scriptable objects/Items/Resources/{type.ToString()}");
            if (newItem == null) newItem = Resources.Load<Item>($"Scriptable objects/Items/Instruments/{type.ToString()}");
            if (newItem == null) Debug.LogWarning($"Unable to load {type.ToString()}");
            else _converter.Add(type, newItem);
        }
    }
}
