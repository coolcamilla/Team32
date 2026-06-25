using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    //TODO: In future, craft material enum should be modified into items, providing opportuinity to drop anything
    [SerializeField] private ItemType _itemType;
    
    private InventoryManager _newInventoryManager;

    private void Start()
    {
        _newInventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //TODO: again, inventory logic also should be rewritten

        bool isAdded = _newInventoryManager.TryAddItem(TypeToItemData.Convert(_itemType));
        if (isAdded) Destroy(gameObject);
    }
}
