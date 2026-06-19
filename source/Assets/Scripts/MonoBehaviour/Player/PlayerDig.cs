using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private float _raycastDistance = 1.5f;

    private PlayerInput _input;
    private GameObject _player;
    private Transform _playerTransform;
    private PlayerMovement _playerMovement;
    private GameObject _stickPrefab;
    private GameObject _stonePrefab;
    private float _horizontalDirection;
    private float _verticalDirection;
    private PlayerManager _playerManager;
    private void Awake()
    {
        _inventoryManager = InventoryManager.GetInstance;
        _player = GameObject.FindWithTag("Player");
        _playerTransform = _player.GetComponent<Transform>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerManager = GameObject.FindWithTag("Game Manager").GetComponent<PlayerManager>();
        _stickPrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stick Object");
        _stonePrefab = Resources.Load<GameObject>("Prefabs/Items/Resources/Stone Object");
        _horizontalDirection = 1;
        _verticalDirection = 0;
        _input = new PlayerInput();
        _input.Player.Look.performed += ChangeVerticalDirection;
        _input.Player.Look.canceled += ResetVerticalDirection;
        _input.Player.DIg.performed += TryDig;
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    private void Update()
    {
        if (PauseManager.IsPaused) return;

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

    public void ChangeHorizontalDirection(float direction)
    {
        _horizontalDirection = direction;
    }

    private void ChangeVerticalDirection(InputAction.CallbackContext context)
    {
        _verticalDirection = context.action.ReadValue<float>();
    }
    private void ResetVerticalDirection(InputAction.CallbackContext context)
    {
        _verticalDirection = 0;
    }

    private Vector2 ComputeRaycastDirection()
    {
        if (_playerMovement != null && _playerMovement.climbMode)
        {
            return new Vector2(_horizontalDirection, 0);
        }

        if (_verticalDirection != 0) return new Vector2(0, _verticalDirection);
        return new Vector2(_horizontalDirection, 0);
    }

    private GameObject SendRaycast()
    {
        Vector2 raycastDirection = ComputeRaycastDirection();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(raycastDirection.x * 1.2f, raycastDirection.y * 2, 0), raycastDirection, _raycastDistance);
        return hit.collider?.gameObject ?? null;
    }

    private void TryDig(InputAction.CallbackContext context)
    {
        GameObject objectHit = SendRaycast();
        if (objectHit != null && objectHit.CompareTag("Block"))
        {
            BlockBehaviour _block = objectHit.GetComponent<BlockBehaviour>();
            _block.TryTakeDamage(_playerManager.CurrentInstrument);
        }
    }
}
