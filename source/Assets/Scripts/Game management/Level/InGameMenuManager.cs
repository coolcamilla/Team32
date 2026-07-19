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

    private MultipleSoundsSourceBehaviour _soundSource;
    private void Awake()
    {
        _previousMenu = null;

        _soundSource = GameObject.FindGameObjectWithTag("Global Audio").GetComponent<MultipleSoundsSourceBehaviour>();
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Input;
        _playerInput.InGameMenu.ToggleInventory.performed += ctx => Toggle(_inventoryMenu);
        _playerInput.InGameMenu.TogglePause.performed += ctx => Toggle(_pauseMenu);
    }


    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void Toggle(GameObject toggledMenu)
    {
        _soundSource.PlayMenuSound();
        CursorToggler.IsVisible = true;
        if (toggledMenu == _previousMenu) ResumeGame();
        else
        {
            Time.timeScale = 0.0f;
            _playerInput.Player.Disable();
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
        _playerInput.Player.Enable();
        _hotbar.SetActive(true);
        _previousMenu.SetActive(false);
        _menuesList.SetActive(false);
        _previousMenu = null;

        CursorToggler.IsVisible = false;
    }
}
