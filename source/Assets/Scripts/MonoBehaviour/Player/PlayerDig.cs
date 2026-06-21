using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDig : MonoBehaviour
{
    [SerializeField] private float _raycastDistance = 1.5f;
    private Animator _animator;

    private PlayerInput _input;
    private GameObject _player;
    private PlayerMovement _playerMovement;
    private float _horizontalDirection;
    private float _verticalDirection;
    private PlayerManager _playerManager;
    private float _timer = 0f;
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _playerManager = GameObject.FindWithTag("Game Manager").GetComponent<PlayerManager>();
        _horizontalDirection = 1;
        _verticalDirection = 0;
        _input = new PlayerInput();
        _animator = GetComponent<Animator>();
        _input.Player.Look.performed += ChangeVerticalDirection;
        _input.Player.Look.canceled += ResetVerticalDirection;
        _input.Player.DIg.performed += TryDig;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
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
        _horizontalDirection = direction;
    }

    private void ChangeVerticalDirection(InputAction.CallbackContext context)
    {
        _verticalDirection = context.action.ReadValue<float>();
        _animator.SetInteger("Direction", (int)_verticalDirection);
    }
    private void ResetVerticalDirection(InputAction.CallbackContext context)
    {
        _verticalDirection = 0;
        _animator.SetInteger("Direction", 0);
    }
    private void TryDig(InputAction.CallbackContext context)
    {
        GameObject objectHit = SendRaycast();
        if (_timer >= _playerManager.EquippedItem.Cooldown && objectHit != null && objectHit.CompareTag("Block"))
        {
            _timer = 0;
            BlockBehaviour _block = objectHit.GetComponent<BlockBehaviour>();
            _block.TryTakeDamage(_playerManager.EquippedItem);
        }
        _animator.SetTrigger("Mining");
    }
    private GameObject SendRaycast()
    {
        Vector2 raycastDirection = ComputeRaycastDirection();
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(raycastDirection.x * 1.2f, raycastDirection.y * 2, 0), raycastDirection, _raycastDistance);
        return hit.collider?.gameObject ?? null;
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


}
