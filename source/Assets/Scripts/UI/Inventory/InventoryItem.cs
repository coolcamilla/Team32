using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private TextMeshProUGUI _countText;

    private Item _item;
    private Image _image;
    private Transform _originalParent;
    private Transform _parentAfterDrag;
    private InventoryManager _inventoryManager;

    private int _count = 1;

    public bool WasHandeledByLogic;
    public Transform OriginalParent => _originalParent;

    public Transform ParentAfterDrag { 
        get { 
            return _parentAfterDrag; 
        }
        set { 
            _parentAfterDrag = value.CompareTag("Slot") ? value : _parentAfterDrag;
        }
    }
    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            if (value > 0)
            {
                _count = value;
                RefreshCount();
            }
            else
            {
                transform.SetParent(transform.root);
                Destroy(gameObject);
            }
        }
    }

    public Item GetItem => _item;

    public void InitializeItem(Item newItem)
    {
        if (_image == null) _image = GetComponent<Image>();

        _item = newItem;
        _image.sprite = newItem.GetSprite;
        _inventoryManager = GameObject.FindWithTag("Game Manager").GetComponent<InventoryManager>();

        RefreshCount();
    }

    private void RefreshCount()
    {
        if (_countText == null) _countText = GetComponentInChildren<TextMeshProUGUI>();
        _countText.text = _count.ToString();
        bool isActive = _count > 1;
        _countText.gameObject.SetActive(isActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _originalParent = transform.parent;
        WasHandeledByLogic = false;

        _parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (WasHandeledByLogic) Destroy(gameObject);

        transform.SetParent(_parentAfterDrag);
        _image.raycastTarget = true;
    }
}
