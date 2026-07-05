using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private GameObject _hintDialog;
    [SerializeField] private GameObject _targetUI;
    [SerializeField] private GameObject _playerUI;

    private PlayerInput _input;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Interact.performed += ToggleTargetUI;

        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Input;
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
        _input.Enable();
    }

    private void HideHint()
    {
        _hintDialog.SetActive(false);
        _targetUI.SetActive(false);
        _input.Disable();
        _playerUI.SetActive(true);
        _playerInput.Player.Dig.Enable();
    }

    private void ToggleTargetUI(InputAction.CallbackContext context)
    {
        _playerUI.SetActive(!_playerUI.activeSelf);
        _targetUI.SetActive(!_targetUI.activeSelf);
        _hintDialog.SetActive(!_targetUI.activeSelf);
        _playerInput.Player.Dig.Disable();
    }
}
