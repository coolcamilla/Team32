using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayMode integration tests for NewCraftManager + InventoryManager.
/// Scene loaded once to avoid NullReferenceException on repeated reloads.
/// Shovel recipe:  10x Stick
/// Pickaxe recipe: 5x Stick + 5x Rock
/// </summary>
public class CraftingIntegrationPlayModeTests
{
    private InventoryManager _inventoryManager;
    private NewCraftManager _craftManager;
    private Item _stick;
    private Item _rock;
    private Item _shovel;
    private Item _pickaxe;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        if (SceneManager.GetActiveScene().name != "Level")
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
            yield return null;
            yield return null;
        }
        else
        {
            yield return null;
        }

        var gameManager = GameObject.FindWithTag("Game Manager");
        Assert.IsNotNull(gameManager, "Game Manager not found in scene.");
        _inventoryManager = gameManager.GetComponent<InventoryManager>();
        _craftManager = gameManager.GetComponent<NewCraftManager>();
        Assert.IsNotNull(_inventoryManager, "InventoryManager not found.");
        Assert.IsNotNull(_craftManager, "NewCraftManager not found.");

        _stick = TypeToItemData.Convert(ItemType.Stick);
        _rock = TypeToItemData.Convert(ItemType.Rock);
        _shovel = TypeToItemData.Convert(ItemType.Shovel);
        _pickaxe = TypeToItemData.Convert(ItemType.Pickaxe);

        ClearInventory();
    }

    private void ClearInventory()
    {
        _inventoryManager.Spend(_stick, 999);
        _inventoryManager.Spend(_rock, 999);
        _inventoryManager.Spend(_shovel, 999);
        _inventoryManager.Spend(_pickaxe, 999);
    }

    // ------------------------------------------------------------------
    // Shovel (10x Stick) — success path
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator TryCraft_Shovel_With10Sticks_ReturnsTrue()
    {
        for (int i = 0; i < 10; i++) _inventoryManager.TryAddItem(_stick);
        yield return null;

        bool result = _craftManager.TryCraft(ItemType.Shovel);
        yield return null;

        Assert.IsTrue(result, "TryCraft should succeed when 10 sticks are available.");
    }

    [UnityTest]
    public IEnumerator TryCraft_Shovel_With10Sticks_SticksConsumedAndShovelAdded()
    {
        for (int i = 0; i < 10; i++) _inventoryManager.TryAddItem(_stick);
        yield return null;

        _craftManager.TryCraft(ItemType.Shovel);
        yield return null;

        Assert.IsFalse(_inventoryManager.IsEnough(_stick, 1),
            "All sticks should be consumed.");
        Assert.IsTrue(_inventoryManager.IsEnough(_shovel, 1),
            "Shovel should appear in inventory.");
    }

    // ------------------------------------------------------------------
    // Shovel — failure path
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator TryCraft_Shovel_WithOnly9Sticks_ReturnsFalseAndInventoryUnchanged()
    {
        for (int i = 0; i < 9; i++) _inventoryManager.TryAddItem(_stick);
        yield return null;

        bool result = _craftManager.TryCraft(ItemType.Shovel);
        yield return null;

        Assert.IsFalse(result, "Should fail with only 9 sticks.");
        Assert.IsTrue(_inventoryManager.IsEnough(_stick, 9),
            "Sticks should not be consumed when crafting fails.");
    }

    // ------------------------------------------------------------------
    // Pickaxe (5x Stick + 5x Rock) — success path
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator TryCraft_Pickaxe_With5SticksAnd5Rocks_ReturnsTrue()
    {
        for (int i = 0; i < 5; i++) _inventoryManager.TryAddItem(_stick);
        for (int i = 0; i < 5; i++) _inventoryManager.TryAddItem(_rock);
        yield return null;

        bool result = _craftManager.TryCraft(ItemType.Pickaxe);
        yield return null;

        Assert.IsTrue(result, "TryCraft should succeed with 5 sticks and 5 rocks.");
    }

    [UnityTest]
    public IEnumerator TryCraft_Pickaxe_MaterialsConsumedAndPickaxeAdded()
    {
        for (int i = 0; i < 5; i++) _inventoryManager.TryAddItem(_stick);
        for (int i = 0; i < 5; i++) _inventoryManager.TryAddItem(_rock);
        yield return null;

        _craftManager.TryCraft(ItemType.Pickaxe);
        yield return null;

        Assert.IsFalse(_inventoryManager.IsEnough(_stick, 1), "Sticks consumed.");
        Assert.IsFalse(_inventoryManager.IsEnough(_rock, 1), "Rocks consumed.");
        Assert.IsTrue(_inventoryManager.IsEnough(_pickaxe, 1), "Pickaxe added.");
    }

    // ------------------------------------------------------------------
    // Pickaxe — failure: missing one material
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator TryCraft_Pickaxe_WithSticksButNoRocks_ReturnsFalse()
    {
        for (int i = 0; i < 5; i++) _inventoryManager.TryAddItem(_stick);
        yield return null;

        bool result = _craftManager.TryCraft(ItemType.Pickaxe);

        Assert.IsFalse(result, "Should fail when rocks are missing.");
    }
}