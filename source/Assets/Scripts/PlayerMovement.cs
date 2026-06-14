using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 2f;
    private Animator _animator;

    private bool _grounded;
    private float _direction;
    private Rigidbody2D _rb;

    private readonly string Horizontal = "Horizontal";

    public float Direction { get { return _direction; } }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        SetPlayerDirection(1);
    }
    private void Update()
    {
        DoMovement();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            _grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            _grounded = false;
        }
    }

    private void DoMovement()
    {
        float horizontalDirection = Input.GetAxisRaw(Horizontal);

        if (horizontalDirection == 0)
        {
            _rb.linearVelocityX = 0;
            _animator.SetBool("IsWalking", false);
        }
        else
        {
            _rb.linearVelocityX = horizontalDirection * _speed;
            _animator.SetBool("IsWalking", true);
            SetPlayerDirection(horizontalDirection);
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (_rb.linearVelocityY == 0 || _grounded)) {
            _rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void SetPlayerDirection(float horizontalDirection)
    {
        _direction = horizontalDirection;
        GetComponent<SpriteRenderer>().flipX = horizontalDirection > 0;
    }
}

