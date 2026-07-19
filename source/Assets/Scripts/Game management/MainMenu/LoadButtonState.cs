using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadButtonState : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Button>().interactable = SaveManager.HasSaveFile();
    }
}
