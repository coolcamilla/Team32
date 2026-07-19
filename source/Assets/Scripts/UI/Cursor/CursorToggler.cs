using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorToggler : MonoBehaviour
{
    public static bool IsVisible;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            IsVisible = true;
        }
        else
        {
            IsVisible = false;
        }
    }

    private void Update()
    {
        Cursor.visible = IsVisible;
    }
}
