using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int coins;
    public float staminaMax;
    public float staminaRegenMultiplier;

    public int[] inventoryTypes;
    public int[] inventoryCounts;

    public int[] craftedTypes;

    public int engineTier;
    public int bitTier;
    public int fuelTankTier;
    public int layerTier;
    public float depth;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    public static bool PendingLoad = false;

    private static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static bool HasSaveFile() => File.Exists(SavePath);

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!PendingLoad)
        {
            CraftTracker.ResetTracker();
            return;
        }
        PendingLoad = false;
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        PlayerStamina stamina = FindObjectOfType<PlayerStamina>();
        DrillBehaviour drill = FindObjectOfType<DrillBehaviour>();

        if (inventory == null || playerManager == null || stamina == null || drill == null)
        {
            Debug.LogWarning("SaveManager: could not find all game systems, skipping save.");
            return;
        }

        SaveData data = new SaveData();

        data.coins = playerManager.Coins;
        data.staminaMax = stamina.MaxStamina;
        data.staminaRegenMultiplier = stamina.Logic.RegenMultiplier;

        InventoryEntry[] slots = inventory.Logic.Slots;
        data.inventoryTypes = new int[slots.Length];
        data.inventoryCounts = new int[slots.Length];
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null || slots[i].StoredItem == null || slots[i].Count <= 0)
            {
                data.inventoryTypes[i] = (int)ItemType.None;
                data.inventoryCounts[i] = 0;
            }
            else
            {
                data.inventoryTypes[i] = (int)slots[i].StoredItem.Type;
                data.inventoryCounts[i] = slots[i].Count;
            }
        }

        ItemType[] crafted = CraftTracker.GetCraftedTypes();
        data.craftedTypes = new int[crafted.Length];
        for (int i = 0; i < crafted.Length; i++) data.craftedTypes[i] = (int)crafted[i];

        data.engineTier = drill.EngineTier;
        data.bitTier = drill.BitTier;
        data.fuelTankTier = drill.FuelTankTier;
        data.layerTier = drill.LayerTier;
        data.depth = drill.Depth;

        try
        {
            File.WriteAllText(SavePath, JsonUtility.ToJson(data, true));
        }
        catch (Exception e)
        {
            Debug.LogError($"SaveManager: failed to write save file: {e.Message}");
        }
    }

    public void LoadGame()
    {
        if (!File.Exists(SavePath)) return;

        SaveData data;
        try
        {
            data = JsonUtility.FromJson<SaveData>(File.ReadAllText(SavePath));
        }
        catch (Exception e)
        {
            Debug.LogError($"SaveManager: failed to read save file: {e.Message}");
            return;
        }

        if (data == null) return;

        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        PlayerStamina stamina = FindObjectOfType<PlayerStamina>();
        DrillBehaviour drill = FindObjectOfType<DrillBehaviour>();

        if (inventory == null || playerManager == null || stamina == null || drill == null)
        {
            Debug.LogWarning("SaveManager: could not find all game systems, skipping load.");
            return;
        }

        playerManager.LoadCoins(data.coins);
        stamina.LoadProgress(data.staminaMax, data.staminaRegenMultiplier);

        ItemType[] invTypes = new ItemType[data.inventoryTypes.Length];
        for (int i = 0; i < invTypes.Length; i++) invTypes[i] = (ItemType)data.inventoryTypes[i];
        inventory.LoadInventory(invTypes, data.inventoryCounts);

        ItemType[] craftedTypes = new ItemType[data.craftedTypes.Length];
        for (int i = 0; i < craftedTypes.Length; i++) craftedTypes[i] = (ItemType)data.craftedTypes[i];
        CraftTracker.LoadCraftedTypes(craftedTypes);

        HotbarBehaviour hotbar = FindObjectOfType<HotbarBehaviour>();
        if (hotbar != null)
        {
            Array.Sort(craftedTypes, (a, b) => ((int)a).CompareTo((int)b));
            foreach (ItemType type in craftedTypes)
            {
                hotbar.ChangeItem(TypeToItemData.Convert(type));
            }
            hotbar.RefreshSelection();
        }

        drill.LoadProgress(data.engineTier, data.bitTier, data.fuelTankTier, data.layerTier, data.depth);
    }

    public void DeleteSave()
    {
        if (File.Exists(SavePath)) File.Delete(SavePath);
    }
}
