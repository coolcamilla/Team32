using UnityEngine;

[RequireComponent(typeof(InventoryManager))]

public class CraftManager : MonoBehaviour
{
    private CraftLogic _logic;
    private HotbarBehaviour _hotbar;

    private void Awake()
    {
        _logic = new CraftLogic(GetComponent<InventoryManager>().Logic, TypeToItemData.Converter);
        _hotbar = GameObject.FindWithTag("Hotbar").GetComponent<HotbarBehaviour>();
    }

    public bool TryCraft(ItemType type)
    {
        if (!CraftTracker.IsCrafted(TypeToItemData.Convert(type).Recipe.RequiredItem) 
            || CraftTracker.IsCrafted(type)
            || !_logic.TryCraft(type)) 
        {  
            return false; 
        }
        if ((int) type >= 100 && (int) type < 300) _hotbar.ChangeItem(TypeToItemData.Convert(type));
        CraftTracker.Update(type);
        return true;
    }
}
