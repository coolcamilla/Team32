using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private GameObject _tutorialUI;
    [SerializeField] private GameObject _playerUI;
    [SerializeField] private Image _tutorialImage;
    private PlayerInput _playerInput;
    private float _initialTimeScale;
    private int _currentSpriteID;
    private bool _initialCursorState;
    private bool _initialPlayerUIState;
    private void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Input;
        _playerInput.UI.Tutorial.performed += ctx => OpenMenu();

        //if (!SaveManager.HasSaveFile())
        OpenMenu();
    }

    private void OpenMenu()
    {
        _initialCursorState = CursorToggler.IsVisible;
        _initialTimeScale = Time.timeScale;
        _initialPlayerUIState = _playerUI.activeSelf;
        CursorToggler.IsVisible = true;

        _playerUI.SetActive(false);
        _playerInput.Disable();
        Time.timeScale = 0f;

        _currentSpriteID = 0;
        _tutorialUI.SetActive(true);
        UpdateSprite();
    }

    private void CloseMenu()
    {
        CursorToggler.IsVisible = _initialCursorState;
        Time.timeScale = _initialTimeScale;
        _playerUI.SetActive(_initialPlayerUIState);
        _playerInput.Enable();

        _tutorialUI.SetActive(false);
    }

    public void NextSprite()
    {
        if (_currentSpriteID == _sprites.Count - 1) CloseMenu();
        else
        {
            _currentSpriteID++;
            UpdateSprite();
        }
    }

    public void PreviousSprite()
    {
        if (_currentSpriteID == 0) return;
        else
        {
            _currentSpriteID--;
            UpdateSprite();
        }
    }

    private void UpdateSprite()
    {
        _tutorialImage.sprite = _sprites[_currentSpriteID];
    }
}
