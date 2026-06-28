using NUnit.Framework;
using UnityEngine;

public class InventoryLogicTests
{
    private InventoryLogic _inventory;
    private Item _stackableItem;
    private Item _nonStackableItem;

    [SetUp]
    public void Setup()
    {
        _inventory = new InventoryLogic(slotCount: 3, maxStackSize: 5);
       
        _stackableItem = ScriptableObject.CreateInstance<Item>();

        _nonStackableItem = ScriptableObject.CreateInstance<Item>();
        _nonStackableItem.ConfigureNonStackableForInventoryTest();
    }

    #region TryAddItem Tests

    [Test]
    public void TryAddItemStackableAddsToFirstEmptySlotWhenInventoryIsEmpty()
    {
        int slotIndex = _inventory.TryAddItem(_stackableItem);

        Assert.AreEqual(0, slotIndex, "Item should be added to the first empty slot (index 0).");
        Assert.AreEqual(1, _inventory.Slots[0].Count, "Count in slot should be 1.");
        Assert.AreSame(_stackableItem, _inventory.Slots[0].StoredItem, "Stored item should be the same.");
    }

    [Test]
    public void TryAddItem_Stackable_StacksUpToMaxSize()
    {
        // Filling the first slot with 5 stackable items
        for (int i = 0; i < 5; i++)
        {
            _inventory.TryAddItem(_stackableItem);
        }

        // Attempt to add the sixth item that should go to the next slot
        int slotIndex = _inventory.TryAddItem(_stackableItem);


        Assert.AreEqual(1, slotIndex, "Item should go to a new slot because the first one is full.");
        Assert.AreEqual(5, _inventory.Slots[0].Count, "First slot should remain at max stack size (5).");
        Assert.AreEqual(1, _inventory.Slots[1].Count, "Second slot should have 1 item.");
    }

    [Test]
    public void TryAddItem_NonStackable_AlwaysGoesToNewSlot()
    {
        int index1 = _inventory.TryAddItem(_nonStackableItem);
        int index2 = _inventory.TryAddItem(_nonStackableItem);

        Assert.AreEqual(0, index1, "First non-stackable goes to slot 0.");
        Assert.AreEqual(1, index2, "Second non-stackable must go to slot 1, not stack with slot 0.");
        Assert.IsNull(_inventory.Slots[2], "Slot 2 should be empty.");
    }

    [Test]
    public void TryAddItem_ReturnsNegativeOne_WhenInventoryIsFull()
    {

        _inventory.TryAddItem(_nonStackableItem);
        _inventory.TryAddItem(_nonStackableItem);
        _inventory.TryAddItem(_nonStackableItem);

        int result = _inventory.TryAddItem(_nonStackableItem);

        Assert.AreEqual(-1, result, "Should return -1 when there is no space.");
    }

    #endregion

    #region IsEnough Tests

    [Test]
    public void IsEnough_ReturnsFalse_WhenItemNotInInventory()
    {
        bool result = _inventory.IsEnough(_stackableItem, 1);

        Assert.IsFalse(result, "Should be false because inventory is empty.");
    }

    [Test]
    public void IsEnough_ReturnsFalse_WhenCountIsInsufficient()
    {
        _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.IsEnough(_stackableItem, 2);

        Assert.IsFalse(result, "Should be false because we need 2, but have only 1.");
    }

    [Test]
    public void IsEnoughReturnsTrueWhenCountAcrossMultipleSlots()
    {
        // Filling the first slot with 5 stackable items
        for (int i = 0; i < 5; i++) _inventory.TryAddItem(_stackableItem);
        // Filling the second slot with 3 stackable items
        for (int i = 0; i < 3; i++) _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.IsEnough(_stackableItem, 7);

        Assert.IsTrue(result, "Should be true because total count across slots is 8 >= 7.");
    }

    #endregion

    #region Spend Tests

    [Test]
    public void SpendReturnsFalseWhenNotEnoughItems()
    {
        _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.Spend(_stackableItem, 5);

        Assert.IsFalse(result, "Should return false because we can't spend 5 when we have 1.");
        Assert.AreEqual(1, _inventory.Slots[0].Count, "Item count should NOT change if spend failed.");
    }

    [Test]
    public void SpendRemovesPartialAmountFromSingleSlot()
    {
        // Fill the first slot with 5 stackable items
        for (int i = 0; i < 5; i++) _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.Spend(_stackableItem, 3);

        Assert.IsTrue(result, "Spend should succeed.");
        Assert.AreEqual(2, _inventory.Slots[0].Count, "Remaining count should be 2.");
        Assert.IsNotNull(_inventory.Slots[0], "Slot should not be null because 2 items remain.");
    }

    [Test]
    public void SpendClearsSlotWhenCountReachesZero()
    {
        // Fill the first slot with 3 stackable items
        for (int i = 0; i < 3; i++) _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.Spend(_stackableItem, 3);

        Assert.IsTrue(result, "Spend should succeed.");
        Assert.IsNull(_inventory.Slots[0], "Slot should be set to null when count reaches 0.");
    }

    [Test]
    public void SpendRemovesItemsAcrossMultipleSlotsWhenNeeded()
    {
        // Fill the first slot with 5 stackable items and the second slot with 5 stackable items (total 10)
        for (int i = 0; i < 10; i++) _inventory.TryAddItem(_stackableItem);

        bool result = _inventory.Spend(_stackableItem, 7);

        Assert.IsTrue(result, "Spend should succeed.");
        Assert.IsNull(_inventory.Slots[0], "First slot should be completely emptied (spent 5 from it).");
        Assert.AreEqual(3, _inventory.Slots[1].Count, "Second slot should have 3 items remaining (5 - 2 = 3).");
    }

    [Test]
    public void SpendDoesNotAffectOtherItems()
    {
        // Fill the first slot with 5 stackable items and the second slot with 1 non-stackable item
        for (int i = 0; i < 5; i++) _inventory.TryAddItem(_stackableItem);
        _inventory.TryAddItem(_nonStackableItem);

        _inventory.Spend(_stackableItem, 5);

        Assert.IsNull(_inventory.Slots[0], "Stackable slot should be empty.");
        Assert.IsNotNull(_inventory.Slots[1], "Non-stackable slot should be untouched.");
        Assert.AreSame(_nonStackableItem, _inventory.Slots[1].StoredItem, "Non-stackable item should be the same.");
    }

    #endregion

    #region MoveOrSwap Tests

    [Test]
    public void MoveOrSwapMovesItemWhenTargetSlotIsEmpty()
    {
        //Put 3 stackable items in slot 0, leave slot 1 empty
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 3 };

        _inventory.MoveOrSwap(0, 1);

        Assert.IsNull(_inventory.Slots[0], "Source slot should be null after moving.");
        Assert.IsNotNull(_inventory.Slots[1], "Target slot should have the item.");
        Assert.AreEqual(3, _inventory.Slots[1].Count, "Item count should be moved entirely.");
    }

    [Test]
    public void MoveOrSwap_SwapsItems_WhenItemsAreDifferent()
    {
        //  Put stackable in 0, non-stackable in 1
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 5 };
        _inventory.Slots[1] = new InventoryEntry { StoredItem = _nonStackableItem, Count = 1 };

        _inventory.MoveOrSwap(0, 1);

        Assert.AreSame(_nonStackableItem, _inventory.Slots[0].StoredItem, "Slot 0 should now have the non-stackable item.");
        Assert.AreSame(_stackableItem, _inventory.Slots[1].StoredItem, "Slot 1 should now have the stackable item.");
        Assert.AreEqual(5, _inventory.Slots[1].Count, "Stackable item count should remain 5.");
    }

    [Test]
    public void MoveOrSwap_StacksFully_WhenTotalDoesNotExceedMaxSize()
    {
        //  2 items in slot 0, 3 items in slot 1 (Max stack is 5)
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 2 };
        _inventory.Slots[1] = new InventoryEntry { StoredItem = _stackableItem, Count = 3 };

        _inventory.MoveOrSwap(0, 1);

        Assert.IsNull(_inventory.Slots[0], "Source slot should be cleared because all items fit.");
        Assert.AreEqual(5, _inventory.Slots[1].Count, "Target slot should have exactly max stack size (5).");
    }

    [Test]
    public void MoveOrSwap_LeavesRemainder_WhenTotalExceedsMaxSize()
    {
        // 4 items in slot 0, 3 items in slot 1 (Total = 7, Max = 5)
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 4 };
        _inventory.Slots[1] = new InventoryEntry { StoredItem = _stackableItem, Count = 3 };

        _inventory.MoveOrSwap(0, 1);

        Assert.AreEqual(5, _inventory.Slots[1].Count, "Target slot should be capped at max stack size (5).");
        Assert.IsNotNull(_inventory.Slots[0], "Source slot should not be null because there is a remainder.");
        Assert.AreEqual(2, _inventory.Slots[0].Count, "Source slot should have the remaining 2 items.");
    }

    [Test]
    public void MoveOrSwap_DoesNothing_WhenMovingToSameSlot()
    {
        //3 items in slot 0
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 3 };

        _inventory.MoveOrSwap(0, 0);

        Assert.IsNotNull(_inventory.Slots[0]);
        Assert.AreEqual(3, _inventory.Slots[0].Count, "Item count should remain unchanged when moving to the same slot.");
    }

    [Test]
    public void MoveOrSwap_DoesNothing_WhenTargetIsFull()
    {
        // 2 items in slot 0, 5 items (FULL) in slot 1
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _stackableItem, Count = 2 };
        _inventory.Slots[1] = new InventoryEntry { StoredItem = _stackableItem, Count = 5 };

        _inventory.MoveOrSwap(0, 1);

        Assert.AreEqual(2, _inventory.Slots[0].Count, "Source should remain unchanged.");
        Assert.AreEqual(5, _inventory.Slots[1].Count, "Target should remain full.");
    }

    [Test]
    public void MoveOrSwap_DoesNotStack_NonStackableItems()
    {
        // Two identical non-stackable items in different slots
        _inventory.Slots[0] = new InventoryEntry { StoredItem = _nonStackableItem, Count = 1 };
        _inventory.Slots[1] = new InventoryEntry { StoredItem = _nonStackableItem, Count = 1 };

        _inventory.MoveOrSwap(0, 1);

        Assert.AreEqual(1, _inventory.Slots[0].Count, "Non-stackable items should not merge.");
        Assert.AreEqual(1, _inventory.Slots[1].Count, "Non-stackable items should not merge.");
    }

    #endregion
}