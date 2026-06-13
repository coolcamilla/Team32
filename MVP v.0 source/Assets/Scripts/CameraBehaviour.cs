using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _timeToReach = 1;
    [SerializeField] private float _velocityFactor = 0.5f;

    private const float _inAirVelocityFactor = 1.4f;
    private Transform _targetTransform;
    private Rigidbody2D _targetRigidbody;
    private bool _isPlayerSeen;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        _targetTransform = _target.transform;
        _targetRigidbody = _target.GetComponent<Rigidbody2D>();
        Vector3 newPosition = _targetTransform.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
    private void LateUpdate()
    {

        if (!_isPlayerSeen)
        {
            Vector3 newPosition = _targetTransform.position;
            newPosition.z = transform.position.z;
            newPosition += new Vector3(_targetRigidbody.linearVelocityX * _velocityFactor, _targetRigidbody.linearVelocityY * _velocityFactor * _inAirVelocityFactor);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, _timeToReach, float.PositiveInfinity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isPlayerSeen = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isPlayerSeen = false;
    }
}

