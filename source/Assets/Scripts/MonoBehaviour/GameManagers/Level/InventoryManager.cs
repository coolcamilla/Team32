using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerManager))]

public class InventoryManager : MonoBehaviour
{
    public readonly int STACK_SIZE = 16;

    [SerializeField] private InventorySlot[] _inventory;
    [SerializeField] private GameObject _inventoryToActivate;

    private GameObject _inventoryItemPrefab;
    private PlayerManager _playerManager;
    private PlayerInput _input;

    private int _selectedSlot = 0;

    private event UnityAction<Item> OnSlotChanged;


    private void Awake()
    {
        _inventoryItemPrefab = Resources.Load<GameObject>("Prefabs/UI/Inventory item");
        _playerManager = GetComponent<PlayerManager>();
        _inventory[_selectedSlot].Select();
        ConfigureInput();
        Cursor.visible = true;
    }
    private void ConfigureInput()
    {
        _input = new();
        _input.UI.Switchinventoryslot.performed += ChangeSlot;
        _input.Inventory.OpenClose.performed += ActivateInventory;
    }

    public void OnEnable()
    {
        OnSlotChanged += _playerManager.ChangeItem;
        _input.Enable();
    }
    public void OnDisable()
    {
        OnSlotChanged -= _playerManager.ChangeItem;
        _input.Disable();
    }
    public bool TryAddItem(Item item)
    {
        int firstEmpty = -1;
        for(int i = 0; i < _inventory.Length && (item.IsStackable || firstEmpty == -1); i++)
        {
            InventorySlot slot = _inventory[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null && firstEmpty == -1) firstEmpty = i;
            else if (itemInSlot != null && 
                itemInSlot.GetItem == item &&
                itemInSlot.Count < STACK_SIZE &&
                itemInSlot.GetItem.IsStackable)
            {
                itemInSlot.Count++;
                return true;
            }
        }
        if (firstEmpty != -1)
        {
            SpawnNewItem(item, _inventory[firstEmpty]);
            return true;
        }
        return false;
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newGameObject = Instantiate(_inventoryItemPrefab, slot.transform);
        InventoryItem newItem = newGameObject.GetComponent<InventoryItem>();
        newItem.InitializeItem(item);
        RefreshChosenSlot();
    }
    private void ChangeSlot(InputAction.CallbackContext context)
    {
        _inventory[_selectedSlot].Deselect();
        _selectedSlot = Mathf.RoundToInt(context.ReadValue<float>());
        _inventory[_selectedSlot].Select();
        RefreshChosenSlot();
    }

    public void RefreshChosenSlot()
    {
        Item newItem = _inventory[_selectedSlot]?.GetComponentInChildren<InventoryItem>()?.GetItem ?? new Item();
        OnSlotChanged(newItem);
    }

    public bool IsEnough(Item item, int count)
    {
        for (int i = 0; i < _inventory.Length; i++)
        { 
            if (item == (_inventory[i]?.GetComponentInChildren<InventoryItem>()?.GetItem))
            {
                count -= _inventory[i].GetComponentInChildren<InventoryItem>().Count;
            }
            if (count <= 0) return true;
        }

        return false;
    }

    public void Spend(Item item, int count)
    {
        for (int i = 0; i < _inventory.Length; i++)
        {
            if (item == (_inventory[i]?.GetComponentInChildren<InventoryItem>()?.GetItem))
            {
                int toSubtract = Mathf.Min(_inventory[i].GetComponentInChildren<InventoryItem>().Count, count);
                count -= _inventory[i].GetComponentInChildren<InventoryItem>().Count;
                _inventory[i].GetComponentInChildren<InventoryItem>().Count -= toSubtract;
            }
            if (count <= 0) return;
        }
    }

    private void ActivateInventory(InputAction.CallbackContext context)
    {
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        _inventoryToActivate.SetActive(!_inventoryToActivate.activeSelf);
        Cursor.visible = true;
    }
}

