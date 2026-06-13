using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference _pointerPositionAction;

    private RectTransform _cursorTransform;
    private Canvas _parentCanvas;
    private RectTransform _canvasRectTransform;
    private Camera _canvasCamera;
    private Image _spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _spriteRenderer = transform.GetChild(0).GetComponent<Image>();
        _cursorTransform = GetComponent<RectTransform>();
        _parentCanvas = GetComponentInParent<Canvas>();

        if ( _parentCanvas != null )
        {
            _canvasRectTransform = _parentCanvas.GetComponent<RectTransform>();
            _canvasCamera = _parentCanvas.renderMode == RenderMode.ScreenSpaceOverlay 
                ? null 
                : _parentCanvas.worldCamera;
        }
    }

    private void OnEnable()
    {
        Cursor.visible = false;
        _pointerPositionAction.action.performed += OnPointerPositionChanged;
        CraftManager.OnItemCrafted += ChangeSprite;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        _pointerPositionAction.action.performed -= OnPointerPositionChanged;
        CraftManager.OnItemCrafted -= ChangeSprite;
    }

    private void OnPointerPositionChanged(InputAction.CallbackContext context)
    {
        if (_cursorTransform == null || _canvasRectTransform == null) return;

        Vector2 mousePosition = context.ReadValue<Vector2>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRectTransform, mousePosition, _canvasCamera, out var localPoint))
        {
            _cursorTransform.anchoredPosition = localPoint;
        }
    }

    public void ChangeSprite(Instrument newInstrument)
    {
        _spriteRenderer.sprite = newInstrument.InstrumentSprite;
    }
}
