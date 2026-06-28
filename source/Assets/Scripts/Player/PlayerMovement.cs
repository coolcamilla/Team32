using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    
    [Header("Climbing")]
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] public float maxClimbingHeight = 12f;

    private PlayerInput _input;

    private bool _grounded;
    private float _horizontalDirection;
    private Rigidbody2D _rb;
    private PlayerDig _playerDig;
    private Collider2D _feetCollider;
    private bool _isClimbing;

    private event UnityAction<float> OnDirectionChange;

    public float Direction { get { return _horizontalDirection; } }
    public bool IsClimbing => _isClimbing;


    private void Awake()
    {
        _isClimbing = false;
        _rb = GetComponent<Rigidbody2D>();
        _playerDig = GetComponent<PlayerDig>();
        _feetCollider = transform.Find("Collider/Feet").GetComponent<Collider2D>();

        ConfigureInput();

        _horizontalDirection = 0;
    }

    private void Update()
    {
        //if (PauseManager.IsPaused) return;
        //if (FindObjectOfType<PauseManager>().IsPaused) return;
        if (FindAnyObjectByType<PauseManager>().IsPaused) return;

        _grounded = _feetCollider.IsTouching(GetBelowColliderWithBoxCast());

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleClimbMode();
        }

        if (_isClimbing)
            DoClimb();
        else
            DoMovement();

        if (_isClimbing)
        {
            Vector3 pos = transform.position;
            if (pos.y > maxClimbingHeight)
            {
                pos.y = maxClimbingHeight;
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


    private void ConfigureInput()
    {
        _input = new PlayerInput();
        _input.Player.Move.performed += OnMove;
        _input.Player.Move.canceled += StopMovement;
        _input.Player.Jump.performed += OnJump;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _horizontalDirection = context.action.ReadValue<float>();
        OnDirectionChange(_horizontalDirection);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    private void ToggleClimbMode()
    {
        _isClimbing = !_isClimbing;
        _rb.gravityScale = _isClimbing ? 0f : 1.5f;

        if (!_isClimbing)
        {
            _rb.linearVelocity = Vector2.zero;
            PlayerAnimator.ChangeWalkingState(false);
        }
    }
    private void DoClimb()
    {
        Vector2 moveInput = new Vector2(_horizontalDirection, Input.GetAxisRaw("Vertical"));

        float speed = climbSpeed > 0 ? climbSpeed : _speed;
        _rb.linearVelocity = moveInput * speed;

        bool isWalking = moveInput.magnitude > 0.1f;
        PlayerAnimator.ChangeWalkingState(isWalking);

        if (Mathf.Abs(_horizontalDirection) > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = _horizontalDirection > 0;
        }
    }
    private void DoMovement()
    {
        if (_horizontalDirection == 0)
        {
            PlayerAnimator.ChangeWalkingState(false);
            return;
        }
        PlayerAnimator.ChangeWalkingState(true);
        _rb.linearVelocityX = _horizontalDirection * _speed;
        GetComponent<SpriteRenderer>().flipX = _horizontalDirection > 0;
    }

    private void Jump()
    {
        if (_isClimbing) return;
        if (_grounded) {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        _horizontalDirection = 0;
        _rb.linearVelocityX = 0;
    }

    private Collider2D GetBelowColliderWithBoxCast()
    {
        Collider2D result = Physics2D.BoxCast(_feetCollider.transform.position - new Vector3(0, 0.5f, 0), new Vector2(0.1f, 0.01f), 0f, Vector2.down).collider;
        return result;
    }
}

