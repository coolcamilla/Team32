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

    private void InitializeFields()
    {
        _image = GetComponent<Image>();
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
        _selectedColor = Color.aquamarine;
        _basicColor = Color.white;
    }

    public void Awake()
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
        
        if (transform.childCount == 0)
        {
            item.ParentAfterDrag = transform;
        } else if (item.GetItem.IsStackable && GetComponentInChildren<InventoryItem>().GetItem == item.GetItem)
        {
            StackItems(item);
        } else {
            ExchangeWithCurrentItem(item);
        }
        _inventoryManager.RefreshChosenSlot();
    }

    private void StackItems(InventoryItem dragged)
    {
        InventoryItem currentInSlot = GetComponentInChildren<InventoryItem>();
        if (currentInSlot.Count + dragged.Count <= _inventoryManager.STACK_SIZE)
        {
            currentInSlot.Count += dragged.Count;
            Destroy(dragged.gameObject);
        } else
        {
            dragged.Count -= _inventoryManager.STACK_SIZE - currentInSlot.Count;
            currentInSlot.Count = _inventoryManager.STACK_SIZE;
        }
    }

    private void ExchangeWithCurrentItem(InventoryItem item)
    {
        InventoryItem currentItemInSlot = GetComponentInChildren<InventoryItem>();
        Transform newParent = item.ParentAfterDrag;
        item.ParentAfterDrag = transform;
        currentItemInSlot.transform.SetParent(newParent);
    }
}
