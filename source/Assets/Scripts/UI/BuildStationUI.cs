using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildStationUI : MonoBehaviour
{
    public static BuildStationUI Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _speedText;
    [SerializeField] private Button _buildButton;
    [Header("Cost UI")]
    [SerializeField] private Transform _costContainer;
    [SerializeField] private GameObject _costItemPrefab;
    [SerializeField] private float _costItemScale = 1.5f;

    private DepositNode _currentNode;

    private void Awake()
    {
        Instance = this;
        _mainPanel.SetActive(false);
    }

    public void ShowUI(DepositNode node, StationRecipe recipe)
    {
        CursorToggler.IsVisible = true;

        _currentNode = node;

        _nameText.text = recipe.stationName;
        _iconImage.sprite = recipe.stationSprite;
        _speedText.text = $"Speed: {recipe.unitsPerMinute} / min";

        foreach (Transform child in _costContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var cost in recipe.buildCost)
        {
            GameObject costItem = Instantiate(_costItemPrefab, _costContainer);

            costItem.transform.localScale = Vector3.one * _costItemScale;

            Image iconImage = costItem.GetComponentInChildren<Image>();
            TextMeshProUGUI countText = costItem.GetComponentInChildren<TextMeshProUGUI>();

            if (iconImage != null && cost.item.GetSprite != null)
            {
                iconImage.sprite = cost.item.GetSprite;
            }

            if(countText != null)
            {
                countText.text = $"x{cost.count}";
            }
        }

        _mainPanel.SetActive(true);
    }

    public void HideUI()
    {
        CursorToggler.IsVisible = false;
        _mainPanel.SetActive(false);
        _currentNode = null;
    }

    public void OnBuildButtonClicked()
    {
        if (_currentNode != null)
        {
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            _currentNode.BuildStation(inventory);
        }
    }

    public bool IsPanelActive()
    {
        return _mainPanel.activeSelf;
    }
}