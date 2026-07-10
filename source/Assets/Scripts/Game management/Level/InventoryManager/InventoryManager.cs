using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public readonly int STACK_SIZE = 99;

    [SerializeField] private InventorySlot[] _inventoryUI;
    [SerializeField] private PlayerDig _playerDig;

    private GameObject _inventoryItemPrefab;

    private InventoryLogic _logic;

    public InventoryLogic Logic => _logic;

    private void Awake()
    {
        _inventoryItemPrefab = Resources.Load<GameObject>("Prefabs/UI/Inventory item");

        _logic = new InventoryLogic(_inventoryUI.Length, STACK_SIZE);
        _logic.OnInventoryChanged += SyncUI;

        SetInventoryIndicies();
    }

    private void SetInventoryIndicies()
    {
        for (int i = 0; i < _inventoryUI.Length; i++) {
            _inventoryUI[i].SlotIndex = i;
        }
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

    public void ClearResources()
    {
        _logic.ClearResources();
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
}