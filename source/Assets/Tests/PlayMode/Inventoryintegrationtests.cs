using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayMode integration tests for InventoryManager.
/// Scene is loaded ONCE to avoid NullReferenceException in OnDisable/OnEnable
/// caused by repeated scene reloads before Awake initializes _input.
/// Inventory is cleared manually between tests.
/// </summary>
public class InventoryIntegrationTests
{
    private InventoryManager _inventoryManager;
    private Item _pebbles;
    private Item _stick;
    private Item _rock;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Only load the scene if it isn't already loaded
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
        Assert.IsNotNull(_inventoryManager, "InventoryManager not found on Game Manager.");

        _pebbles = TypeToItemData.Convert(ItemType.Pebbles);
        _stick = TypeToItemData.Convert(ItemType.Stick);
        _rock = TypeToItemData.Convert(ItemType.Rock);

        ClearInventory();
    }

    /// <summary>
    /// Spends all of each item type to reset inventory state between tests.
    /// </summary>
    private void ClearInventory()
    {
        _inventoryManager.Spend(_pebbles, 999);
        _inventoryManager.Spend(_stick, 999);
        _inventoryManager.Spend(_rock, 999);
    }

    // ------------------------------------------------------------------
    // TryAddItem
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator TryAddItem_Pebbles_ReturnsTrue()
    {
        bool result = _inventoryManager.TryAddItem(_pebbles);
        yield return null;

        Assert.IsTrue(result, "TryAddItem should return true for Pebbles.");
    }

    [UnityTest]
    public IEnumerator TryAddItem_Pebbles_AppearsInInventory()
    {
        _inventoryManager.TryAddItem(_pebbles);
        yield return null;

        Assert.IsTrue(_inventoryManager.IsEnough(_pebbles, 1),
            "Pebbles should be present after adding.");
    }

    [UnityTest]
    public IEnumerator TryAddItem_SameStackableItemTwice_CountIsTwo()
    {
        _inventoryManager.TryAddItem(_pebbles);
        _inventoryManager.TryAddItem(_pebbles);
        yield return null;

        Assert.IsTrue(_inventoryManager.IsEnough(_pebbles, 2),
            "Two pebbles should stack to count of 2.");
    }

    // ------------------------------------------------------------------
    // IsEnough
    // ------------------------------------------------------------------

    [UnityTest]
    public IEnumerator IsEnough_AddedOneItem_EnoughForOneButNotTwo()
    {
        _inventoryManager.TryAddItem(_rock);
        yield return null;

        Assert.IsTrue(_inventoryManager.IsEnough(_rock, 1));
        Assert.IsFalse(_inventoryManager.IsEnough(_rock, 2));
    }
}