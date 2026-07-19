using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Exit()
    {
        SaveManager.Instance?.SaveGame();

        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
