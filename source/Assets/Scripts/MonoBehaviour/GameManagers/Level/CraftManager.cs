using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class NewCraftManager : MonoBehaviour
{
    [SerializeField] private GameObject _craftPanel;

    private InventoryManager _inventoryManager;


    private void Awake()
    {
        _inventoryManager = GetComponent<InventoryManager>();
    }

    public bool TryCraft(ItemType type)
    {
        Item item = TypeToItemData.Convert(type);

        if (IsPossibleToCraft(item))
        {
            Craft(item);
            return true;
        }

        return false;
    }

    private bool IsPossibleToCraft(Item item)
    {
        CraftRecipe recipe = item.Recipe;
        foreach(MaterialAndQuantity maq in recipe.Materials) 
        {
            if (!_inventoryManager.IsEnough(TypeToItemData.Convert(maq.Type), maq.Quantity)) return false;
        }
        return true;
    }

    private void Craft(Item item)
    {
        CraftRecipe recipe = item.Recipe;
        foreach (MaterialAndQuantity maq in recipe.Materials)
        {
            _inventoryManager.Spend(TypeToItemData.Convert(maq.Type), maq.Quantity);
        }
        _inventoryManager.TryAddItem(item);
    }
}
