using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanelRenderer : MonoBehaviour
{
    private GameObject _materialCountPrefab;

    private TextMeshProUGUI nameOnPanel;
    private TextMeshProUGUI descriptionOnPanel;
    private Image imageOnPanel;
    private Transform materialsScrollViewportOnPanel;
    private ItemType _renderedType;
    private NewCraftManager _craftManager;

    private void Awake()
    {
        _renderedType = ItemType.None;
        _materialCountPrefab = Resources.Load<GameObject>("Prefabs/UI/Material count");

        _craftManager = GameObject.FindWithTag("Game Manager").GetComponent<NewCraftManager>();

        nameOnPanel = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        descriptionOnPanel = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        imageOnPanel = transform.Find("Icon").GetComponent<Image>();
        materialsScrollViewportOnPanel = transform.Find("Materials/Viewport/Content");
    }
    public void RenderPanel(int index)
    {
        if (_renderedType == (ItemType) index && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        } else gameObject.SetActive(true);

        _renderedType = (ItemType)index;
        Item item = TypeToItemData.Convert(_renderedType);
        CraftRecipe recipe = item.Recipe;

        nameOnPanel.SetText(recipe.Name);
        descriptionOnPanel.SetText(recipe.Description);
        imageOnPanel.sprite = recipe.GetSprite;

        foreach (Transform child in materialsScrollViewportOnPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var pair in recipe.Materials)
        {
            GameObject newCount = Instantiate(_materialCountPrefab, transform.position, Quaternion.identity);
            newCount.transform.SetParent(materialsScrollViewportOnPanel);
            newCount.GetComponentInChildren<TextMeshProUGUI>().SetText($"x{pair.Quantity}");
            newCount.GetComponentInChildren<Image>().sprite = TypeToItemData.Convert(pair.Type).GetSprite;
        }
    }

    public void DelegateCurrentCraft()
    {
        _craftManager.TryCraft(_renderedType);
    }
}
