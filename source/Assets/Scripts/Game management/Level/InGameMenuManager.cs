using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InGameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuesList;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _inventoryMenu;
    [SerializeField] private GameObject _hotbar;

    private GameObject _previousMenu;
    private PlayerInput _playerInput;
    private PlayerInput _input;
    private UnityAction _onGamePaused;
    private UnityAction _onGameResumed;
    private void Awake()
    {
        _previousMenu = null;
        _input = new PlayerInput();
        _input.InGameMenu.ToggleInventory.performed += ctx => Toggle(_inventoryMenu);
        _input.InGameMenu.TogglePause.performed += ctx => Toggle(_pauseMenu);
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Input;
    }


    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void Toggle(GameObject toggledMenu)
    {
        if (toggledMenu == _previousMenu) ResumeGame();
        else
        {
            Time.timeScale = 0.0f;
            _playerInput.Disable();
            _hotbar.SetActive(false);
            _menuesList.SetActive(true);
            _previousMenu?.SetActive(false);
            toggledMenu.SetActive(true);
            _previousMenu = toggledMenu;
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _playerInput.Enable();
        _hotbar.SetActive(true);
        _previousMenu.SetActive(false);
        _menuesList.SetActive(false);
        _previousMenu = null;
    }
}
