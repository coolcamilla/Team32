using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InventoryManager : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _stickCounter;
    [SerializeField] private TextMeshProUGUI _stoneCounter;

    private static Dictionary<CraftMaterial, int> _inventory;

    private static InventoryManager _instance;
    public static InventoryManager GetInstance
    {
        get
        {
            if (_instance == null)
                _instance = new();
            return _instance;
        }
    }

    private void LateUpdate()
    {
        _stickCounter.SetText(_inventory[CraftMaterial.Stick].ToString());
        _stoneCounter.SetText(_inventory[CraftMaterial.Stone].ToString());
    }
    
    /// <summary>
    /// Should be called by gamemangaer from the start.
    /// Method works only once, parallel to all initializations.
    /// </summary>
    public static void Init()
    {
        if (_inventory != null) return;
        _inventory = new Dictionary<CraftMaterial, int>();

        foreach (CraftMaterial material in Enum.GetValues(typeof(CraftMaterial)))
        {
            if (material == CraftMaterial.None) continue;

            _inventory.Add(material, 0);
        }
    }
    public void AddMaterial(CraftMaterial material, int amount = 1)
    {
        _inventory[material] += amount;
    }

    public bool TrySpendMaterial(CraftMaterial material, int amount = 1)
    {
        if (IsEnough(material,amount))
        {
            RemoveMaterial(material, amount);
            return true;
        }

        Debug.Log("Not enough of " + material.ToString());
        return false;
    }
    
    public bool IsEnough(CraftMaterial material, int amount = 1)
    {
        return _inventory[material] >= amount;
    }

    private void RemoveMaterial(CraftMaterial material, int amount = 1)
    {
        _inventory[material] -= amount;
    }
}
