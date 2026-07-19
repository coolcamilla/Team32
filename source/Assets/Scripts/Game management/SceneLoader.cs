using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    public void LoadSceneByIndex(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }

    public void LoadSavedGameByIndex(int index)
    {
        SaveManager.PendingLoad = true;
        LoadSceneByIndex(index);
    }

    public void SaveAndLoadSceneByIndex(int index)
    {
        SaveManager.Instance?.SaveGame();
        LoadSceneByIndex(index);
    }
}
