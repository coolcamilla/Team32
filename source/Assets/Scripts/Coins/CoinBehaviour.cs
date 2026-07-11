using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private PlayerManager _playerManager;
    private bool _isHarevested;

    private void Start()
    {
        _playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        _isHarevested = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _isHarevested) return;

        _isHarevested = true;
        _playerManager.AddCoin();
        Destroy(gameObject);
    }
}
