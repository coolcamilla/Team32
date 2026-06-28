using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[RequireComponent(typeof(InventoryManager))]

public class CraftManager : MonoBehaviour
{
    private CraftLogic _logic;

    private void Awake()
    {
        _logic = new CraftLogic(GetComponent<InventoryManager>().Logic, TypeToItemData.Converter);
    }

    public bool TryCraft(ItemType type)
    {
        return _logic.TryCraft(type);
    }
}
