using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    private PlayerInput _input;

    private Animator _animator;

    private bool _grounded;
    private float _direction;
    private Rigidbody2D _rb;
    private PlayerDig _playerDig;

    private event UnityAction<float> OnDirectionChange;

    public float Direction { get { return _direction; } }

    [Header("Climbing")]
    public bool climbMode = false;
    public float climbSpeed = 5f;
    public float maxClimbHigh = 8f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _playerDig = GetComponent<PlayerDig>();

        ConfigureInput();

        _direction = 0;
    }

    private void Update()
    {
        if (PauseManager.IsPaused) return;

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleClimbMode();
        }

        if (climbMode)
            DoClimb();
        else
            DoMovement();

        if (climbMode)
        {
            Vector3 pos = transform.position;
            if (pos.y > maxClimbHigh)
            {
                pos.y = maxClimbHigh;
                transform.position = pos;
                _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
            }
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (climbMode) return;
        if (collision.gameObject.tag == "Block")
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (climbMode) return;
        if (collision.gameObject.tag == "Block")
        {
            _grounded = false;
        }
    }

    private void ConfigureInput()
    {
        _input = new PlayerInput();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += StopMovement;
        _input.Player.Jump.performed += OnJump;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.action.ReadValue<float>();
        OnDirectionChange(_direction);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    private void ToggleClimbMode()
    {
        climbMode = !climbMode;
        _rb.gravityScale = climbMode ? 0f : 1f;

        if (!climbMode)
        {
            _rb.linearVelocity = Vector2.zero;
            _animator.SetBool("IsWalking", false);
        }
    }
    private void DoClimb()
    {
        Vector2 moveInput = new Vector2(_direction, Input.GetAxisRaw("Vertical"));

        float speed = climbSpeed > 0 ? climbSpeed : _speed;
        _rb.linearVelocity = moveInput * speed;

        bool isWalking = moveInput.magnitude > 0.1f;
        _animator.SetBool("IsWalking", isWalking);

        if (Mathf.Abs(_direction) > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = _direction > 0;
        }
    }
    private void DoMovement()
    {
        if (_direction == 0)
        {
            _animator.SetBool("IsWalking", false);
            return;
        }
        _animator.SetBool("IsWalking", true);
        _rb.linearVelocityX = _direction * _speed;
        GetComponent<SpriteRenderer>().flipX = _direction > 0;
    }

    private void Jump()
    {
        if (climbMode) return;
        if (_rb.linearVelocityY == 0 || _grounded) {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        _direction = 0;
        _rb.linearVelocityX = 0;
    }
}

