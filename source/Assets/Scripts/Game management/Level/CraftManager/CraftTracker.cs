using System;
using System.Collections.Generic;
using UnityEngine;

public static class CraftTracker
{
    private static Dictionary<ItemType, bool> _tracker;

    public static bool IsCrafted(ItemType type)
    {
        if (_tracker == null) InitializeTracker();

        if (IsNotInstrument(type)) return true;

        return _tracker[type];
    }

    public static void Update(ItemType type)
    {
        if (_tracker == null) InitializeTracker();
        _tracker[type] = true;
    }
    private static void InitializeTracker()
    {
        _tracker = new Dictionary<ItemType, bool>();
        foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            if (IsNotInstrument(type)) continue;
            _tracker.Add(type, false);
        }
    }

    public static ItemType[] GetCraftedTypes()
    {
        if (_tracker == null) InitializeTracker();

        List<ItemType> result = new List<ItemType>();
        foreach (var pair in _tracker)
        {
            if (pair.Value) result.Add(pair.Key);
        }
        return result.ToArray();
    }

    public static void ResetTracker()
    {
        InitializeTracker();
    }

    public static void LoadCraftedTypes(ItemType[] types)
    {
        InitializeTracker();
        foreach (ItemType type in types)
        {
            if (_tracker.ContainsKey(type)) _tracker[type] = true;
        }
    }

    private static bool IsNotInstrument(ItemType type)
    {
        return type < ItemType.WoodenShovel || type >= ItemType.Stick;
    }
}
