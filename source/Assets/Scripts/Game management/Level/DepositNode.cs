using UnityEngine;

public class DepositNode : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject _pressFPrompt;
    [SerializeField] private GameObject _stationPrefab;
    [SerializeField] private Vector3 _stationOffset = new Vector3(0, 0.5f, 0);

    private Vector2 _checkAreaSize = new Vector2(4f, 4f);

    private bool _isPlayerNear = false;
    private bool _isBuilt = false;
    private StationRecipe _stationRecipe;

    public void Initialize(StationRecipe recipe)
    {
        _stationRecipe = recipe;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBuilt || _stationRecipe == null) return;
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isBuilt) return;
        if (other.CompareTag("Player"))
        {
            _isPlayerNear = false;
            if (_pressFPrompt != null) _pressFPrompt.SetActive(false);
            BuildStationUI.Instance.HideUI();
        }
    }

    private void Update()
    {
        if (_isBuilt || !_isPlayerNear) return;

        bool blocksCleared = AreForegroundBlocksCleared();

        if (_pressFPrompt != null && _pressFPrompt.activeSelf != blocksCleared)
        {
            _pressFPrompt.SetActive(blocksCleared);
        }

        if (blocksCleared && Input.GetKeyDown(KeyCode.F))
        {
            if (BuildStationUI.Instance.IsPanelActive())
            {
                BuildStationUI.Instance.HideUI();
            }
            else
            {
                BuildStationUI.Instance.ShowUI(this, _stationRecipe);
            }
        }
    }

    private bool AreForegroundBlocksCleared()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, _checkAreaSize, 0f);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Block") && !hit.isTrigger)
            {
                return false;
            }
        }

        return true;
    }

    public void BuildStation(InventoryManager inventory)
    {
        foreach (var cost in _stationRecipe.buildCost)
        {
            if (!inventory.IsEnough(cost.item, cost.count)) return;
        }

        foreach (var cost in _stationRecipe.buildCost)
        {
            inventory.Spend(cost.item, cost.count);
        }

        GameObject stationGo = Instantiate(_stationPrefab, transform.position + _stationOffset, Quaternion.identity);
        MiningStation station = stationGo.GetComponent<MiningStation>();
        station.Initialize(_stationRecipe);

        _isBuilt = true;
        if (_pressFPrompt != null) _pressFPrompt.SetActive(false);
        BuildStationUI.Instance.HideUI();

        GetComponent<Collider2D>().enabled = false;
    }
}