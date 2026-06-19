using System.Collections.Generic;
using System;
using UnityEngine;

public static class MaterialToPrefab
{
    private static Dictionary<CraftMaterial, GameObject> _materialToPrefab;
    
    public static Dictionary<CraftMaterial, GameObject> GetDictionary { 
        get
        {
            if (_materialToPrefab == null) InitializeDictionary();
            return _materialToPrefab;
        }
    }

    public static GameObject Convert(CraftMaterial material)
    {
        if (_materialToPrefab == null) InitializeDictionary();
        return _materialToPrefab[material];
    }

    private static void InitializeDictionary()
    {
        _materialToPrefab = new Dictionary<CraftMaterial, GameObject>();

        foreach(CraftMaterial material in Enum.GetValues(typeof(CraftMaterial)))
        {
            string name = material.ToString();
            if (name == "None") continue;
            GameObject newPrefab = Resources.Load<GameObject>($"Prefabs/Items/Resources/{name} Object");
            if (newPrefab == null)
            {
                Debug.LogWarning($"Have not found {name} Object prefab");
                continue;
            }
            _materialToPrefab.Add(material, newPrefab);
        }
    }
}
