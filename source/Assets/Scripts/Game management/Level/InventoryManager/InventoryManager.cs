using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public readonly int STACK_SIZE = 16;

    [SerializeField] private InventorySlot[] _inventoryUI;
    [SerializeField] private GameObject _inventoryToActivate;
    [SerializeField] private PlayerDig _playerDig;

    private GameObject _inventoryItemPrefab;
    private PlayerManager _playerManager;
    private PlayerInput _input;

    private int _selectedSlot = 0;
    private InventoryLogic _logic;

    private event UnityAction<Item> OnSlotChanged;

    public InventoryLogic Logic => _logic;

    private void Awake()
    {
        _inventoryItemPrefab = Resources.Load<GameObject>("Prefabs/UI/Inventory item");
        _playerManager = PlayerManager.Instance;

        _logic = new InventoryLogic(_inventoryUI.Length, STACK_SIZE);
        _logic.OnInventoryChanged += SyncUI;
        _logic.OnInventoryChanged += RefreshChosenSlot;

        SetInventoryIndicies();
        _inventoryUI[_selectedSlot].Select();

        ConfigureInput();

    }

    private void ConfigureInput()
    {
        _input = new();
        _input.UI.Switchinventoryslot.performed += ChangeSlot;
        _input.Inventory.OpenClose.performed += ActivateInventory;
    }

    private void SetInventoryIndicies()
    {
        for (int i = 0; i < _inventoryUI.Length; i++) {
            _inventoryUI[i].SlotIndex = i;
        }
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
        int slotIndex = _logic.TryAddItem(item);

        if (slotIndex != -1)
        {
            return true;
        }
        return false;
    }

    public bool IsEnough(Item item, int count = 1)
    {
        return _logic.IsEnough(item, count);
    }

    public void Spend(Item item, int count = 1)
    {
        _logic.Spend(item, count);
    }

    public void MoveItem(int from, int to)
    {
        _logic.MoveOrSwap(from, to);
    }
    private void SyncUI()
    {
        for (int i = 0; i < _inventoryUI.Length; i++)
        {
            InventorySlot uiSlot = _inventoryUI[i];
            InventoryEntry data = _logic.Slots[i];

            InventoryItem itemInUI = uiSlot.GetComponentInChildren<InventoryItem>();

            if (data == null || data.Count <= 0)
            {
                if (itemInUI != null) Destroy(itemInUI.gameObject);
            }
            else
            {
                if (itemInUI == null || itemInUI.GetItem != data.StoredItem)
                {
                    if (itemInUI != null) Destroy(itemInUI.gameObject);

                    GameObject newGo = Instantiate(_inventoryItemPrefab, uiSlot.transform);
                    itemInUI = newGo.GetComponent<InventoryItem>();
                    itemInUI.InitializeItem(data.StoredItem);
                }

                itemInUI.Count = data.Count;
            }
        }
    }

    private void ChangeSlot(InputAction.CallbackContext context)
    {
        _inventoryUI[_selectedSlot].Deselect();
        _selectedSlot = Mathf.RoundToInt(context.ReadValue<float>());
        _inventoryUI[_selectedSlot].Select();
        RefreshChosenSlot();
    }

    public void RefreshChosenSlot()
    {
        InventoryEntry entry = _logic.Slots[_selectedSlot];
        Item newItem = (entry != null) ? entry.StoredItem : Item.CreateInstance<Item>(); 

        OnSlotChanged?.Invoke(newItem);
    }

    private void ActivateInventory(InputAction.CallbackContext context)
    {
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        if (!_inventoryToActivate.activeSelf)
        {
            _playerDig.enabled = false;
            _inventoryToActivate.SetActive(true);
        }
        else
        {
            _playerDig.enabled = true;
            _inventoryToActivate.SetActive(false);
        }
    }
}