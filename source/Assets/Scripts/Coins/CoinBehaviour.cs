using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private PlayerManager _playerManager;
    private bool _isHarevested;

    private static MultipleSoundsSourceBehaviour _audioSource;

    private void Start()
    {
        if (_audioSource == null) 
            _audioSource = GameObject.FindGameObjectWithTag("Global Audio").GetComponent<MultipleSoundsSourceBehaviour>();
        _playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        _isHarevested = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || _isHarevested) return;

        _isHarevested = true;
        _playerManager.AddCoin();
        _audioSource.PlayCoinCollectedSound();
        Destroy(gameObject);
    }
}
