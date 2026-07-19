using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _connectedButton;

    private GameObject _materialCountPrefab;
    
    private void Initialize()
    {
        _materialCountPrefab = Resources.Load<GameObject>("Prefabs/UI/Material Count");
    }

    public void Refresh(CraftRecipe recipe)
    {
        if (_materialCountPrefab == null) Initialize();

        if (recipe == null)
        {
            Delete();
            return;
        }

        Clear();

        foreach(var entry in recipe.Materials)
        {
            GameObject newCounter = Instantiate(_materialCountPrefab, transform.position, Quaternion.identity);
            newCounter.transform.SetParent(transform);
            newCounter.GetComponentInChildren<TextMeshProUGUI>().SetText($"x{entry.Quantity}");
            newCounter.GetComponentInChildren<Image>().sprite = TypeToItemData.Convert(entry.Type).GetSprite;
            newCounter.transform.localScale = Vector3.one / 2;
        }
    }
    private void Delete()
    {
        Clear();
        Destroy(_connectedButton.gameObject);
    }
    private void Clear()
    {
        foreach(Transform child in transform)
        {
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }
    }

}
