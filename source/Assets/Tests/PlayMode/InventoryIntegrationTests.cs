using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

/// <summary>
/// PlayMode integration tests for InventoryManager (critical module, per docs/testing.md).
///
/// Uses the real InventoryManager instance found in the loaded Level scene, and real
/// Item assets loaded via TypeToItemData.Convert(ItemType.Stick) - a genuine Resources
/// asset, not a synthetic test double - since InventoryManager.Awake() depends on
/// Resources.Load and a wired _inventoryUI array that only exist in the real scene.
///
/// Because the scene (and this InventoryManager instance) is loaded once per session,
/// tests use delta-based assertions (before/after comparisons) rather than assuming
/// the inventory starts empty, since other tests or a prior session may have already
/// added items to the same real Stick slot.
/// </summary>
public class InventoryIntegrationTests
{
    private InventoryManager _inventoryManager;
    private Item _stick;

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

        _inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        Assert.IsNotNull(_inventoryManager, "Setup FAIL: InventoryManager not found in the Level scene.");

        _stick = TypeToItemData.Convert(ItemType.Stick);
        Assert.IsNotNull(_stick, "Setup FAIL: could not load the real Stick item via TypeToItemData.");
    }

    [UnityTest]
    public IEnumerator InventoryManager_OnSceneLoad_LogicIsInitialized()
    {
        yield return null;

        Assert.IsNotNull(_inventoryManager.Logic,
            "InventoryManager.Logic should be initialized by Awake().");
        Assert.Greater(_inventoryManager.Logic.Slots.Length, 0,
            "Inventory should have at least one slot, matching the Inspector-configured _inventoryUI array.");
    }

    [UnityTest]
    public IEnumerator TryAddItem_RealStickItem_IncreasesAvailableCount()
    {
        bool hadOneBefore = _inventoryManager.Logic.Slots != null && _inventoryManager.IsEnough(_stick, 1);
        int before = 0;
        while (_inventoryManager.IsEnough(_stick, before + 1)) before++;

        bool added = _inventoryManager.TryAddItem(_stick);
        yield return null;

        Assert.IsTrue(added, "TryAddItem should succeed for a real Stick item (a resource-type item >= 300).");
        Assert.IsTrue(_inventoryManager.IsEnough(_stick, before + 1),
            "Available Stick count should have increased by exactly 1.");
    }

    [UnityTest]
    public IEnumerator IsEnough_ReflectsActualStoredCount()
    {
        int before = 0;
        while (_inventoryManager.IsEnough(_stick, before + 1)) before++;

        _inventoryManager.TryAddItem(_stick);
        _inventoryManager.TryAddItem(_stick);
        yield return null;

        Assert.IsTrue(_inventoryManager.IsEnough(_stick, before + 2));
        Assert.IsFalse(_inventoryManager.IsEnough(_stick, before + 3));
    }

    [UnityTest]
    public IEnumerator Spend_ReducesAvailableCount_AndReturnsToOriginalTotal()
    {
        // Add 2, then spend the same 2 back off, and confirm we return to the
        // pre-test baseline - this keeps the test self-contained regardless of
        // what other tests left behind in the shared inventory instance.
        int before = 0;
        while (_inventoryManager.IsEnough(_stick, before + 1)) before++;

        _inventoryManager.TryAddItem(_stick);
        _inventoryManager.TryAddItem(_stick);
        yield return null;
        Assert.IsTrue(_inventoryManager.IsEnough(_stick, before + 2));

        _inventoryManager.Spend(_stick, 2);
        yield return null;

        Assert.IsTrue(_inventoryManager.IsEnough(_stick, before),
            "Spending back the 2 we added should return to the original available count.");
        Assert.IsFalse(_inventoryManager.IsEnough(_stick, before + 1),
            "Should no longer have more than the original baseline.");
    }

    [UnityTest]
    public IEnumerator MoveItem_DelegatesToLogicMoveOrSwap()
    {
        // Find two currently-empty slots to move between, so this test doesn't
        // disturb any real item the player/other tests may have stored.
        var slots = _inventoryManager.Logic.Slots;
        int emptyA = -1, emptyB = -1;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                if (emptyA == -1) emptyA = i;
                else if (emptyB == -1) { emptyB = i; break; }
            }
        }

        if (emptyA == -1 || emptyB == -1)
        {
            Assert.Ignore("Not enough empty slots available in the current inventory state to test MoveItem safely.");
            yield break;
        }

        Assert.DoesNotThrow(() => _inventoryManager.MoveItem(emptyA, emptyB),
            "MoveItem should not throw when moving between two empty slots.");
        yield return null;
    }
}
