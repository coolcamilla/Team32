using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _gameUI;
    private static bool _isPaused;

    public static bool IsPaused { get { return _isPaused; } }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.UI.Callpausemenu.performed += OnEscape;

        _isPaused = false;
        Resume();
    }

    private void OnEnable()
    {
        _playerInput.Enable();

    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        ChangeState();
    }

    public void ChangeState()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _pauseUI.SetActive(true);
        _gameUI.SetActive(false);
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        _pauseUI.SetActive(false);
        _gameUI.SetActive(true);
    }
}
