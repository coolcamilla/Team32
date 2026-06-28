using System.Collections.Generic;
using System;
using UnityEngine;

public static class TypeToPrefab
{
    private static Dictionary<ItemType, GameObject> _typeToPrefab;
    
    public static Dictionary<ItemType, GameObject> GetDictionary { 
        get
        {
            if (_typeToPrefab == null)
            {
                InitializeDictionary();
            }
            return _typeToPrefab;
        }
    }

    public static GameObject Convert(ItemType material)
    {
        if (_typeToPrefab == null)
        {
            InitializeDictionary();

        }
        return _typeToPrefab[material];
    }

    private static void InitializeDictionary()
    {
        _typeToPrefab = new Dictionary<ItemType, GameObject>();

        foreach(ItemType type in Enum.GetValues(typeof(ItemType)))
        {
            if ((int) type < 100) continue;
            string name = type.ToString();
            GameObject newPrefab = Resources.Load<GameObject>($"Prefabs/Items/{name}");

            if (newPrefab == null)
            {
                Debug.LogWarning($"Have not found {name} prefab");
                continue;
            }
            _typeToPrefab.Add(type, newPrefab);
        }
    }
}
