using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour
{
    [SerializeField] private PlayerStamina _playerStamina;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private InventoryManager _inventoryManager;

    [SerializeField] private GameObject _deathScreenPanel;
    [SerializeField] private float _respawnDelay = 10f;

    private void Start()
    {
        if (_deathScreenPanel != null)
        {
            _deathScreenPanel.SetActive(false);
        }

        if (_playerStamina != null && _playerStamina.Logic != null)
        {
            _playerStamina.Logic.OnDeath += StartDeathSequence;
        }
    }

    private void OnDisable()
    {
        _playerStamina.Logic.OnDeath -= StartDeathSequence;
    }

    private void StartDeathSequence()
    {
        _playerStamina.Logic.OnDeath -= StartDeathSequence;

        if (_deathScreenPanel != null)
        {
            _deathScreenPanel.SetActive(true);
        }

        _playerMovement.HandleDeath();
        StartCoroutine(RespawnRoutine());
    }

    private IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(_respawnDelay);

        if (_deathScreenPanel != null)
        {
            _deathScreenPanel.SetActive(false);

            _inventoryManager.ClearResources();

            _playerMovement.Respawn();
            _playerStamina.Respawn();

            _playerStamina.Logic.OnDeath += StartDeathSequence;
        }
    }
}
