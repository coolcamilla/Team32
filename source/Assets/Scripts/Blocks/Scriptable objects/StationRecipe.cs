using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewStationRecipe", menuName = "MoleDigger/Station Recipe")]
public class StationRecipe : ScriptableObject
{
    public string stationName = "Clay Drill";
    public Sprite stationSprite;

    [Header("Production")]
    public GameObject producedItemPrefab;
    public int unitsPerMinute = 5;

    [Header("Build Cost")]
    public List<ItemCost> buildCost;

    [System.Serializable]
    public struct ItemCost
    {
        public Item item;
        public int count;
    }

    public float GetMiningInterval()
    {
        if (unitsPerMinute <= 0) return Mathf.Infinity;
        return 60f / unitsPerMinute;
    }
}