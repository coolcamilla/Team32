using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerManager))]

public class PlayerDig : MonoBehaviour
{
    [SerializeField] private float _raycastDistance = 1.5f;

    public float cellSize = 2.5f;

    // The offset is used to adjust the starting position of the raycast based on the player's size
    private readonly Vector2 START_POSITION_OFFSET = new Vector2(1.2f, 2f);

    private PlayerInput _input;
    private PlayerMovement _playerMovement;
    private PlayerManager _playerManager;
    private PlayerDigLogic _logic;

    private PlayerSoundsManager _audioSource;

    public event UnityAction<float> OnVerticalDirectionChange;
    public event UnityAction OnAnyDig;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerManager = GetComponent<PlayerManager>();
        _audioSource = GetComponent<PlayerSoundsManager>();

        _input = _playerManager.Input;
        _input.Player.Look.performed += ChangeVerticalDirection;
        _input.Player.Look.canceled += ResetVerticalDirection;
        _input.Player.Dig.performed += TryDig;

        _logic = PlayerDigLogic.Instance;
        OnVerticalDirectionChange += _logic.ChangeVerticalDirection;
    }

    private void Update()
    {
        _logic.UpdateTimer(Time.deltaTime);
    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }

    public void ChangeHorizontalDirection(float direction)
    {
        if (direction == 0) return;
        _logic.ChangeHorizontalDirection(direction);
    }
    private void ChangeVerticalDirection(InputAction.CallbackContext context)
    {
        float value = context.action.ReadValue<float>();
        OnVerticalDirectionChange?.Invoke(value);
    }
    private void ResetVerticalDirection(InputAction.CallbackContext context)
    {
        OnVerticalDirectionChange?.Invoke(0);
    }
    private void TryDig(InputAction.CallbackContext context)
    {
        if (_playerMovement.IsDead) return;
        if (_playerMovement.IsClimbing) return;

        OnAnyDig?.Invoke();
        GameObject objectHit = GetObjectOnDigDirection();

        if (objectHit != null)
        {
            if (GridGenerator.Instance != null)
            {
                Vector3 blockPos = objectHit.transform.position;
                float baseStartX = GridGenerator.Instance.baseStartX;
                float baseEndX = GridGenerator.Instance.baseEndX;

                if (blockPos.x >= baseStartX && blockPos.x <= baseEndX)
                {
                    int height = GridGenerator.Instance.height;

                    float surfaceWorldY = (height - 1) * cellSize;
                    float minAllowedDigY = surfaceWorldY - (3 * cellSize);

                    if (blockPos.y > minAllowedDigY)
                    {
                        return;
                    }
                }
            }

            if (_logic.BlockHit(objectHit, _playerManager.EquippedItem))
            {
                if (objectHit.GetComponent<BlockBehaviour>().TryTakeDamage(_playerManager.EquippedItem))
                {
                    _audioSource.PlayPLayerDiggingSound();
                }
            }
        }
    }
    private GameObject GetObjectOnDigDirection()
    {
        Vector2 raycastDirection = _logic.ComputeRaycastDirection(_playerMovement.IsClimbing);

        RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position + Vector2.Scale(raycastDirection, START_POSITION_OFFSET), raycastDirection, _raycastDistance);
        
        return hit.collider?.gameObject ?? null;
    }
}