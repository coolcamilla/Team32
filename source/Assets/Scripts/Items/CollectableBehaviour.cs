using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] private ItemType _itemType;
    private bool _isHarvested;
    private InventoryManager _inventoryManager;

    private static MultipleSoundsSourceBehaviour _audioSource;

    private void Start()
    {
        if (_audioSource == null)
            _audioSource = GameObject.FindGameObjectWithTag("Global Audio").GetComponent<MultipleSoundsSourceBehaviour>();
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _isHarvested) return;

        bool isAdded = _inventoryManager.TryAddItem(TypeToItemData.Convert(_itemType));
        if (isAdded)
        {
            _isHarvested = true;
            Destroy(gameObject);
            _audioSource.PlayItemCollectedSound();
        }
    }
}
