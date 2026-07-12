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
    [SerializeField] private TextMeshProUGUI _recipeText;
    [SerializeField] private Button _buildButton;

    private DepositNode _currentNode;

    private void Awake()
    {
        Instance = this;
        _mainPanel.SetActive(false);
    }

    public void ShowUI(DepositNode node, StationRecipe recipe)
    {
        _currentNode = node;

        _nameText.text = recipe.stationName;
        _iconImage.sprite = recipe.stationSprite;
        _speedText.text = $"Speed: {recipe.unitsPerMinute} / min";

        string recipeStr = "Cost:\n";
        foreach (var cost in recipe.buildCost)
        {
            recipeStr += $"{cost.item.name} x{cost.count}\n";
        }
        _recipeText.text = recipeStr;

        _mainPanel.SetActive(true);
    }

    public void HideUI()
    {
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