using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CraftPanelRenderer : MonoBehaviour
{
    [SerializeField] private List<Craftbuttonbehaviour> _buttons;
    private GameObject _materialCountPrefab;
    private TextMeshProUGUI nameOnPanel;
    private TextMeshProUGUI descriptionOnPanel;
    private Image imageOnPanel;
    private Transform RecipeContentsOnPanel;
    private ItemType _renderedType;
    private CraftManager _craftManager;
    private RectTransform _rectTransform;
    private MultipleSoundsSourceBehaviour _audioSource;
    private void Awake()
    {
        _renderedType = ItemType.None;
        _rectTransform = GetComponent<RectTransform>();
        _materialCountPrefab = Resources.Load<GameObject>("Prefabs/UI/Material count");

        _audioSource = GameObject.FindGameObjectWithTag("Global Audio").GetComponent<MultipleSoundsSourceBehaviour>();

        _craftManager = GameObject.FindWithTag("Game Manager").GetComponent<CraftManager>();

        nameOnPanel = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        descriptionOnPanel = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        imageOnPanel = transform.Find("Icon").GetComponent<Image>();
        RecipeContentsOnPanel = transform.Find("Materials");
    }
    public void RenderPanel(ItemType type, RectTransform position)
    {
        /*if (_renderedType == type && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        }*/

        gameObject.SetActive(true);

        _rectTransform.position = new Vector3(position.position.x, _rectTransform.position.y, _rectTransform.position.z);

        _renderedType = type;
        Item item = TypeToItemData.Convert(_renderedType);
        CraftRecipe recipe = item.Recipe;

        nameOnPanel.SetText(recipe.Name);
        descriptionOnPanel.SetText(recipe.Description);
        imageOnPanel.sprite = recipe.GetSprite;

        foreach (Transform child in RecipeContentsOnPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var pair in recipe.Materials)
        {
            GameObject newCount = Instantiate(_materialCountPrefab, transform.position, Quaternion.identity);
            newCount.transform.SetParent(RecipeContentsOnPanel);
            newCount.GetComponentInChildren<TextMeshProUGUI>().SetText($"x{pair.Quantity}");
            newCount.GetComponentInChildren<Image>().sprite = TypeToItemData.Convert(pair.Type).GetSprite;
        }
    }

    public void DelegateCurrentCraft()
    {
        if (!_craftManager.TryCraft(_renderedType)) return;

        foreach(Craftbuttonbehaviour button in _buttons)
        {
            if (button.ItemTypeToCraft == _renderedType)
            {
                button.MarkDone();
                break;
            }
        }

        _audioSource.PlayCraftSound();

        gameObject.SetActive(false);
    }
}
