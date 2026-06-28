using UnityEngine;
using UnityEngine.InputSystem;

public class DrillSign : MonoBehaviour
{
    [SerializeField] private GameObject _hintDialog;
    [SerializeField] private GameObject _drillUI;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Interact.performed += ToggleDrillUI;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ShowHint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HideHint();
        }
    }

    private void ShowHint()
    {
        _hintDialog.SetActive(true);
        _playerInput.Enable();
    }

    private void HideHint()
    {
        _hintDialog.SetActive(false);
        _drillUI.SetActive(false);
        _playerInput.Disable();
    }

    private void ToggleDrillUI(InputAction.CallbackContext context)
    {
        _drillUI.SetActive(!_drillUI.activeSelf);
        _hintDialog.SetActive(!_drillUI.activeSelf);
    }
}
