using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private InventoryManager _inventoryManager;
    public int SlotIndex;

    private void Awake()
    {
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem item = dropped.GetComponent<InventoryItem>();

        int fromIndex = item.OriginalParent.GetComponent<InventorySlot>().SlotIndex;
        int toIndex = SlotIndex;

        item.WasHandeledByLogic = true;
        _inventoryManager.MoveItem(fromIndex, toIndex);
        
    }
}
