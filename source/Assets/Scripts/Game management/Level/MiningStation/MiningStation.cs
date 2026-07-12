using UnityEngine;

public class MiningStation : MonoBehaviour
{
    private StationRecipe _recipe;
    private MiningStationLogic _logic;

    public void Initialize(StationRecipe recipe)
    {
        _recipe = recipe;
        _logic = new MiningStationLogic(_recipe.GetMiningInterval());
    }

    private void Update()
    {
        if (_logic == null) return;

        if (_logic.Tick(Time.deltaTime))
        {
            ProduceResource();
        }
    }

    private void ProduceResource()
    {
        if (_recipe == null || _recipe.producedItemPrefab == null) return;

        Vector3 dropPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 1.5f, 0f);

        Instantiate(_recipe.producedItemPrefab, dropPosition, Quaternion.identity);
    }
}