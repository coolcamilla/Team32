using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
public class Craftbuttonbehaviour : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private ItemType _itemToCraft;
    [SerializeField] private CraftPanelRenderer _panel;
    [SerializeField] private bool _isAvailable;
    [SerializeField] private List<Craftbuttonbehaviour> _nextButtons;
    private Image _image;

    private bool _isDone = false;

    public ItemType ItemTypeToCraft => _itemToCraft;

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            _image = child.GetComponent<Image>();
            break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isAvailable || _isDone) return;
        _panel.RenderPanel(_itemToCraft, GetComponent<RectTransform>());
    }

    private void OpenButton()
    {
        _isAvailable = true;
        GetComponent<Image>().color = Color.white;
        _image.sprite = TypeToItemData.Convert(_itemToCraft).GetSprite;
    }

    public void MarkDone()
    {
        GetComponent<Image>().color = Color.green;
        _isDone = true;
        foreach(Craftbuttonbehaviour button in _nextButtons)
        {
            button.OpenButton();
        }
    }
}
