using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PauseLogic _pauseLogic;

    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _gameUI;
    public bool IsPaused => _pauseLogic.IsPaused;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _pauseLogic = new PauseLogic();

        _pauseLogic.OnPaused += HandlePause;
        _pauseLogic.OnResumed += HandleResume;

        _pauseLogic.Resume();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.UI.Callpausemenu.performed += OnEscape;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.UI.Callpausemenu.performed -= OnEscape;
    }

    private void OnDestroy()
    {
        _pauseLogic.OnPaused -= HandlePause;
        _pauseLogic.OnResumed -= HandleResume;
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        _pauseLogic.TogglePause();
    }

    public void ChangeState()
    {
        _pauseLogic.TogglePause();
    }

    private void HandlePause()
    {
        Time.timeScale = 0f;
        _pauseUI.SetActive(true);
        _gameUI.SetActive(false);
        _playerInput.Player.Disable();
    }

    private void HandleResume()
    {
        Time.timeScale = 1f;
        _pauseUI.SetActive(false);
        _gameUI.SetActive(true);
        _playerInput.Player.Enable();
    }
}