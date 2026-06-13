using UnityEngine;

public class PlayerDig : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;

    private GameObject _player;
    private Transform _playerTransform;
    private PlayerMovement _playerMovement;
    private GameObject _stickPrefab;
    private GameObject _stonePrefab;
    private void Start()
    {
        _inventoryManager = InventoryManager.GetInstance;
        _player = GameObject.FindWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _stickPrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stick Object");
        _stonePrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stone Object");
    }

    // Update is called once per frame
    void Update()
    {
        bool tryResult;
        GameObject newObject;
        if (Input.GetKeyDown(KeyCode.Z)) {
            tryResult = _inventoryManager.TrySpendMaterial(CraftMaterial.Stick);
            if (tryResult)
            {
                newObject = Instantiate(_stickPrefab,
                    _playerTransform.position + new Vector3(_playerMovement.Direction, 0) * 1.7f,
                    Quaternion.identity);
                newObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(_playerMovement.Direction, 0) * 100);
            }
        } else if (Input.GetKeyDown(KeyCode.X)) {
            tryResult = _inventoryManager.TrySpendMaterial(CraftMaterial.Stone);
            if (tryResult)
            {
                newObject = Instantiate(_stonePrefab,
                    _playerTransform.position + new Vector3(_playerMovement.Direction, 0) * 1.7f,
                    Quaternion.identity);
                newObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(_playerMovement.Direction, 0) * 100);
            }
        }
    }
}
