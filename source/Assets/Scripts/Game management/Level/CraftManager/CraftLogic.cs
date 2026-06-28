using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftLogic
{
    private InventoryLogic _inventoryLogic;
    private Dictionary<ItemType, Item> _converter;

    public CraftLogic(InventoryLogic inventoryManager, Dictionary<ItemType, Item> converter)
    {
        _inventoryLogic = inventoryManager;
        _converter = converter;
    }

    public bool TryCraft(ItemType type)
    {
        Item item = _converter[type];

        if (IsPossibleToCraft(item))
        {
            Craft(item);
            return true;
        }

        return false;
    }

    public bool IsPossibleToCraft(Item data)
    {
        CraftRecipe recipe = data.Recipe;
        foreach (MaterialAndQuantity maq in recipe.Materials)
        {
            if (!_inventoryLogic.IsEnough(_converter[maq.Type], maq.Quantity)) return false;
        }
        return true;
    }

    private void Craft(Item item)
    {
        CraftRecipe recipe = item.Recipe;
        foreach (MaterialAndQuantity maq in recipe.Materials)
        {
            _inventoryLogic.Spend(_converter[maq.Type], maq.Quantity);
        }
        _inventoryLogic.TryAddItem(item);
    }
}
