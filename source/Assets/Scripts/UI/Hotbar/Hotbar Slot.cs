using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HotbarSlot : MonoBehaviour
{
    [SerializeField] private HotbarSlotType _type;
    [SerializeField] private Image _icon;

    private TextMeshProUGUI _hotKeyRenderer;
    private PlayerManager _playerManager;
    private Image _image;
    private Item _currentItem;

    private static Color _selectedColor;
    private static Color _basicColor;

    public Item GetItem => _currentItem;

    private void Awake()
    {
        InitializeFields();
    }

    private void InitializeFields()
    {
        _hotKeyRenderer = GetComponentInChildren<TextMeshProUGUI>();
        _hotKeyRenderer.SetText(((int) _type).ToString());

        _playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        _currentItem = Item.CreateInstance<Item>();
        _image = GetComponent<Image>();
        _selectedColor = Color.aquamarine;
        _basicColor = Color.white;
    }

    public void Select()
    {
        if (_image == null) InitializeFields();
        _image.color = _selectedColor;
        _playerManager.ChangeItem(_currentItem);
    }

    public void Deselect()
    {
        if (_image == null) InitializeFields();
        _image.color = _basicColor;
    }

    public bool TrySetNewItem(Item item)
    {
        if (IsSlotSuitableForItem(item))
        {
            _currentItem = item;
            _icon.sprite = _currentItem.GetSprite;
            return true;
        } else
        {
            Debug.LogError($"Slot {_type} is not suitable for the item {item.Type}");
            return false;
        }
    }

    private bool IsSlotSuitableForItem(Item item)
    {
        return (int) item.Type >= (int) _type * 100 && (int) item.Type < (int) _type * 100 + 40 || item.Type == ItemType.None; 
    }
}
