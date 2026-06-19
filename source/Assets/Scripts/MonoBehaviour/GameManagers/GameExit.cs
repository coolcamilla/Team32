using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
