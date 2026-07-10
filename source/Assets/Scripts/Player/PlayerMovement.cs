using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerStamina))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    
    [Header("Climbing")]
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float maxClimbHeight = 12f;

    private PlayerInput _input;
    private PlayerStamina _stamina;
    private PlayerMovementLogic _logic;
    private PlayerDig _playerDig;
    private PlayerManager _playerManager;

    private Rigidbody2D _rb;
    private Collider2D _feetCollider;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _startPosition;
    private bool _isDead = false;
    public bool IsDead => _isDead;

    private event UnityAction<float> OnDirectionChange;

    public float Direction => _logic.IsClimbing ? 0 : _logic.HorizontalInput;
    public bool IsClimbing => _logic.IsClimbing;


    private void Awake()
    {
        _startPosition = transform.position;

        _logic = new PlayerMovementLogic
        {
            Speed = _speed,
            JumpForce = _jumpForce,
            ClimbSpeed = climbSpeed,
            RotationSpeed = rotationSpeed,
            BaseGravityScale = 1.5f
        };

        _rb = GetComponent<Rigidbody2D>();
        _playerDig = GetComponent<PlayerDig>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _stamina = GetComponent<PlayerStamina>();
        _playerManager = GetComponent<PlayerManager>();
        _feetCollider = transform.Find("Collider/Feet").GetComponent<Collider2D>();

        ConfigureInput();
    }

    private void UpdateClimbToggle()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            bool changed = _logic.ToggleClimbMode(_stamina.CanClimb());

            if (changed)
            {
                _rb.gravityScale = _logic.GetTargetGravityScale();
                if (!_logic.IsClimbing) _rb.linearVelocity = Vector2.zero;
            }
        }
    }

    private void Update()
    {
        if (_isDead) return;

        _logic.IsGrounded = _feetCollider.IsTouching(GetBelowColliderWithBoxCast());
        _logic.SetVerticalDirection(Input.GetAxisRaw("Vertical"));

        if (_logic.IsClimbing && _logic.IsMoving())
            _stamina.Drain(Time.deltaTime);
        else if (!_logic.IsClimbing)
            _stamina.Regenerate(Time.deltaTime);

        _logic.Tick(Time.deltaTime);

        _rb.gravityScale = _logic.GetTargetGravityScale();

        Vector2 targetVelocity = _logic.CalculateMovementVelocity();

        if (_logic.IsClimbing)
        {
            _rb.linearVelocity = targetVelocity;
            transform.rotation = Quaternion.Euler(0, 0, -_logic.CurrentAngle);
        }
        else
        {
            _rb.linearVelocityX = targetVelocity.x;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10f);
        }

        if (_logic.IsClimbing)
        {
            Vector3 pos = transform.position;
            if (pos.y > maxClimbHeight)
            {
                pos.y = maxClimbHeight;
                transform.position = pos;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
            }
        }

        bool isMoving = _logic.IsMoving();

        PlayerAnimator.ChangeClimbingState(_logic.IsClimbing);

        if (!_logic.IsClimbing)
        {
            PlayerAnimator.ChangeWalkingState(isMoving);
            if (Mathf.Abs(_logic.HorizontalInput) > 0.1f)
                _spriteRenderer.flipX = _logic.ShouldFlipX();
        }
        else
        {
            PlayerAnimator.ChangeWalkingState(false);
        }

        UpdateClimbToggle();
    }

    public void HandleDeath()
    {
        _isDead = true;
        _logic.SetHorizontalDirection(0);
        _logic.SetVerticalDirection(0);
        _logic.ForceStopClimbing();

        _rb.linearVelocity = Vector2.zero;
        _rb.gravityScale = 0;
    }

    public void Respawn()
    {
        transform.position = _startPosition;
        _isDead = false;
        _rb.gravityScale = 0;
    }

    private void OnEnable()
    {
        _input.Enable();
        OnDirectionChange += _playerDig.ChangeHorizontalDirection;
    }

    private void OnDisable()
    {
        _input.Disable();
        OnDirectionChange -= _playerDig.ChangeHorizontalDirection;
    }


    private void ConfigureInput()
    {
        _input = _playerManager.Input;
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += StopMovement;
        _input.Player.Jump.performed += OnJump;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (_isDead) return;
        float dir  = context.action.ReadValue<float>();
        _logic.SetHorizontalDirection(dir);
        OnDirectionChange?.Invoke(dir);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_isDead) return;
        if (_logic.CanJump())
        {
            _rb.AddForce(_logic.GetJumpForceVector());
        }
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        if (_isDead) return;
        _logic.SetHorizontalDirection(0);
        if (!_logic.IsClimbing) OnDirectionChange?.Invoke(0);
    }

    private Collider2D GetBelowColliderWithBoxCast()
    {
        return Physics2D.BoxCast(_feetCollider.transform.position - new Vector3(0, 0.5f, 0), new Vector2(0.1f, 0.01f), 0f, Vector2.down).collider;
    }
}

