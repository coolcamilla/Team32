using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    //TODO: In future, craft material enum should be modified into items, providing opportuinity to drop anything
    [SerializeField] private CraftMaterial _itemType;
    
    private InventoryManager _inventory;

    private void Start()
    {
        _inventory = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        //TODO: again, inventory logic also should be rewritten
        _inventory.AddMaterial(_itemType);
        Destroy(gameObject);
    }
}
