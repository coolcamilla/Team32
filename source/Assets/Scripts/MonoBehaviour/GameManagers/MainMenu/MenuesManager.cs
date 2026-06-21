using UnityEngine;

public class MenuesManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _newGameMenu;
    [SerializeField] private GameObject _loadGameMenu;

    private void Awake()
    {
        Cursor.visible = true;
    }
    private void resetAll()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(false);
        _newGameMenu.SetActive(false);
        _loadGameMenu.SetActive(false);
    }

    public void RenderMainMenu()
    {
        resetAll();
        _mainMenu.SetActive(true);
    }

    public void RenderSettingsMenu()
    {
        resetAll();
        _settingsMenu.SetActive(true);
    }

    public void RenderNewGameMenu()
    {
        resetAll();
        _newGameMenu.SetActive(true);
    }

    public void RenderLoadGameMenu()
    {
        resetAll();
        _loadGameMenu.SetActive(true);
    }
}
