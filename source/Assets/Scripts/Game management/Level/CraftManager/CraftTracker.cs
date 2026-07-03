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

    private static bool IsNotInstrument(ItemType type)
    {
        return type < ItemType.WoodenShovel || type >= ItemType.Stick;
    }
}
