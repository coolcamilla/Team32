using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private Image _image;
    private InventoryManager _inventoryManager;
    private static Color _selectedColor;
    private static Color _basicColor;

    public int SlotIndex;

    private void InitializeFields()
    {
        _image = GetComponent<Image>();
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
        _selectedColor = Color.aquamarine;
        _basicColor = Color.white;
    }

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        if (_image == null) InitializeFields();
        _image.color = _selectedColor;
    }

    public void Deselect()
    {
        if (_image == null) InitializeFields();
        _image.color = _basicColor;
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
