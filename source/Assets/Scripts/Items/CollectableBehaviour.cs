using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    
    private InventoryManager _inventoryManager;

    private void Start()
    {
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        bool isAdded = _inventoryManager.TryAddItem(TypeToItemData.Convert(_itemType));
        if (isAdded) Destroy(gameObject);
    }
}
