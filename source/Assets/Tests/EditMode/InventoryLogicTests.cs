using NUnit.Framework;
using UnityEngine;

/// <summary>
/// EditMode unit tests for InventoryLogic - plain C#, no scene dependency.
///
/// Key real-code constraints this file is written against:
/// - TryAddItem rejects any item with (int)item.Type &lt; 300 (instruments/services),
///   so a "resource" item must have a type in that range to be addable. Item.
///   ConfigureItemForCraftTestMaterial() sets Type = ItemType.Stick (300), which is
///   the only real test configurator that produces an addable item.
/// - Item is a ScriptableObject; equality checks in InventoryLogic (IsSlotSuitable,
///   MoveOrSwap's stacking check) use Unity's reference-based equality. Two separately
///   created Item instances, even identically configured, are NOT considered the same
///   item for stacking purposes - only repeated calls with the same instance stack.
/// </summary>
public class InventoryLogicTests
{
    private const int SlotCount = 5;
    private const int MaxStackSize = 3;

    private InventoryLogic CreateLogic(int slotCount = SlotCount, int maxStackSize = MaxStackSize)
    {
        return new InventoryLogic(slotCount, maxStackSize);
    }

    private Item CreateResourceItem()
    {
        var item = ScriptableObject.CreateInstance<Item>();
        item.ConfigureItemForCraftTestMaterial(); // Type = ItemType.Stick (300), stackable by default
        return item;
    }

    private Item CreateNonStackableResourceItem()
    {
        var item = ScriptableObject.CreateInstance<Item>();
        item.ConfigureItemForCraftTestMaterial(); // Type = ItemType.Stick (300)
        item.ConfigureNonStackableForInventoryTest(); // IsStackable = false
        return item;
    }

    private Item CreateUnaddableInstrumentItem()
    {
        var item = ScriptableObject.CreateInstance<Item>();
        item.ConfigureToNotDefaultForTesting(); // Type = ItemType.Test (1), still < 300
        return item;
    }

    [Test]
    public void Constructor_CreatesEmptySlotsArrayOfRequestedSize()
    {
        var logic = CreateLogic(slotCount: 5);

        Assert.AreEqual(5, logic.Slots.Length);
        foreach (var slot in logic.Slots)
        {
            Assert.IsNull(slot);
        }
    }

    [Test]
    public void TryAddItem_ResourceItem_SucceedsAndOccupiesASlot()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();

        int slotIndex = logic.TryAddItem(item);

        Assert.AreNotEqual(-1, slotIndex, "Adding a resource-type item (>= 300) should succeed.");
        Assert.AreEqual(item, logic.Slots[slotIndex].StoredItem);
        Assert.AreEqual(1, logic.Slots[slotIndex].Count);
    }

    [Test]
    public void TryAddItem_InstrumentTypeItem_IsRejected()
    {
        var logic = CreateLogic();
        var item = CreateUnaddableInstrumentItem(); // Type = Test = 1, < 300

        int slotIndex = logic.TryAddItem(item);

        Assert.AreEqual(-1, slotIndex,
            "TryAddItem should reject items with (int)Type < 300 per InventoryLogic's guard clause.");
    }

    [Test]
    public void TryAddItem_SameStackableItemTwice_StacksIntoSameSlot()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem(); // stackable by default

        int firstSlot = logic.TryAddItem(item);
        int secondSlot = logic.TryAddItem(item); // same reference

        Assert.AreEqual(firstSlot, secondSlot, "Adding the same stackable item reference twice should reuse the same slot.");
        Assert.AreEqual(2, logic.Slots[firstSlot].Count);
    }

    [Test]
    public void TryAddItem_SameNonStackableItemTwice_CreatesTwoSeparateSlots()
    {
        var logic = CreateLogic();
        var item = CreateNonStackableResourceItem();

        int firstSlot = logic.TryAddItem(item);
        int secondSlot = logic.TryAddItem(item); // same reference, but not stackable

        Assert.AreNotEqual(firstSlot, secondSlot,
            "A non-stackable item should occupy a new slot on each add, not stack.");
        Assert.AreEqual(1, logic.Slots[firstSlot].Count);
        Assert.AreEqual(1, logic.Slots[secondSlot].Count);
    }

    [Test]
    public void TryAddItem_ExceedingMaxStackSize_OverflowsIntoNewSlot()
    {
        var logic = CreateLogic(slotCount: 5, maxStackSize: 2);
        var item = CreateResourceItem();

        int slot1 = logic.TryAddItem(item); // count 1
        int slot2 = logic.TryAddItem(item); // count 2, at max
        int slot3 = logic.TryAddItem(item); // should overflow to a new slot

        Assert.AreEqual(slot1, slot2, "Second add should still fit within maxStackSize.");
        Assert.AreEqual(2, logic.Slots[slot1].Count);
        Assert.AreNotEqual(slot1, slot3, "Third add should overflow into a different slot once maxStackSize is reached.");
        Assert.AreEqual(1, logic.Slots[slot3].Count);
    }

    [Test]
    public void TryAddItem_WhenInventoryFull_ReturnsMinusOne()
    {
        var logic = CreateLogic(slotCount: 1, maxStackSize: 1);
        var itemA = CreateNonStackableResourceItem();
        var itemB = CreateNonStackableResourceItem(); // different reference

        int firstResult = logic.TryAddItem(itemA);
        int secondResult = logic.TryAddItem(itemB);

        Assert.AreNotEqual(-1, firstResult);
        Assert.AreEqual(-1, secondResult, "TryAddItem should return -1 when no slot is available.");
    }

    [Test]
    public void TryAddItem_RaisesOnInventoryChanged()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        bool eventFired = false;
        logic.OnInventoryChanged += () => eventFired = true;

        logic.TryAddItem(item);

        Assert.IsTrue(eventFired);
    }

    [Test]
    public void IsEnough_TrueWhenRequiredCountAvailable()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        logic.TryAddItem(item);
        logic.TryAddItem(item);

        Assert.IsTrue(logic.IsEnough(item, 2));
    }

    [Test]
    public void IsEnough_FalseWhenRequiredCountNotAvailable()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        logic.TryAddItem(item);

        Assert.IsFalse(logic.IsEnough(item, 5));
    }

    [Test]
    public void IsEnough_FalseWhenItemNotPresentAtAll()
    {
        var logic = CreateLogic();
        var presentItem = CreateResourceItem();
        var absentItem = CreateResourceItem(); // different reference, never added
        logic.TryAddItem(presentItem);

        Assert.IsFalse(logic.IsEnough(absentItem, 1));
    }

    [Test]
    public void Spend_SufficientAmount_ReturnsTrueAndReducesCount()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        logic.TryAddItem(item);
        logic.TryAddItem(item);
        logic.TryAddItem(item); // count = 3

        bool result = logic.Spend(item, 2);

        Assert.IsTrue(result);
        Assert.IsTrue(logic.IsEnough(item, 1));
        Assert.IsFalse(logic.IsEnough(item, 2));
    }

    [Test]
    public void Spend_InsufficientAmount_ReturnsFalseAndDoesNotModifyInventory()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        logic.TryAddItem(item); // count = 1

        bool result = logic.Spend(item, 5);

        Assert.IsFalse(result);
        Assert.IsTrue(logic.IsEnough(item, 1), "Inventory should be unchanged after a failed Spend.");
    }

    [Test]
    public void Spend_ExactAmount_EmptiesTheSlot()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        int slot = logic.TryAddItem(item); // count = 1

        bool result = logic.Spend(item, 1);

        Assert.IsTrue(result);
        Assert.IsNull(logic.Slots[slot], "Slot should be cleared (set to null) when its full count is spent.");
    }

    [Test]
    public void Spend_AcrossOverflowedSlots_ConsumesFromBothSlots()
    {
        // Force an overflow into a second slot for the same item reference, then spend
        // an amount that requires drawing from both slots.
        var logic = CreateLogic(slotCount: 5, maxStackSize: 2);
        var item = CreateResourceItem();
        logic.TryAddItem(item); // slot A, count 1
        logic.TryAddItem(item); // slot A, count 2 (at max)
        logic.TryAddItem(item); // slot B, count 1 (overflow)

        bool result = logic.Spend(item, 3); // total available across both slots = 3

        Assert.IsTrue(result);
        Assert.IsFalse(logic.IsEnough(item, 1), "All 3 should be spent across both slots.");
    }

    [Test]
    public void MoveOrSwap_DifferentItems_SwapsSlotContents()
    {
        var logic = CreateLogic();
        var itemA = CreateResourceItem();
        var itemB = CreateNonStackableResourceItem();
        int slotA = logic.TryAddItem(itemA);
        int slotB = logic.TryAddItem(itemB);

        logic.MoveOrSwap(slotA, slotB);

        Assert.AreEqual(itemB, logic.Slots[slotA].StoredItem);
        Assert.AreEqual(itemA, logic.Slots[slotB].StoredItem);
    }

    [Test]
    public void MoveOrSwap_SameStackableItemWithRoom_MergesIntoTargetSlot()
    {
        var logic = CreateLogic(slotCount: 5, maxStackSize: 5);
        var item = CreateResourceItem();
        int slotA = logic.TryAddItem(item); // count 1

        // Force a second slot for the same reference by filling slotA to a point,
        // then manually relocate: simplest way is via MoveOrSwap after another add
        // creates a second occupied slot with the same item via a full first slot.
        // Simpler: swap into an empty slot first, then move a second copy on top of it.
        int emptySlot = logic.Slots.Length - 1;
        logic.MoveOrSwap(slotA, emptySlot); // item now in emptySlot, slotA is empty
        logic.TryAddItem(item); // goes into slotA again (first empty slot found), count 1

        logic.MoveOrSwap(slotA, emptySlot); // move/merge slotA's copy into emptySlot

        Assert.IsNull(logic.Slots[slotA], "Source slot should be cleared after a full merge.");
        Assert.AreEqual(2, logic.Slots[emptySlot].Count, "Target slot should now hold both units.");
    }

    [Test]
    public void MoveOrSwap_OutOfBoundsIndices_DoesNotThrow()
    {
        var logic = CreateLogic();

        Assert.DoesNotThrow(() => logic.MoveOrSwap(-1, 0));
        Assert.DoesNotThrow(() => logic.MoveOrSwap(0, 999));
    }

    [Test]
    public void MoveOrSwap_EmptySourceSlot_DoesNothing()
    {
        var logic = CreateLogic();
        var item = CreateResourceItem();
        int occupiedSlot = logic.TryAddItem(item);
        int emptySlot = occupiedSlot == 0 ? 1 : 0;

        logic.MoveOrSwap(emptySlot, occupiedSlot); // from is empty

        Assert.AreEqual(item, logic.Slots[occupiedSlot].StoredItem,
            "Moving from an empty slot should leave the target slot untouched.");
    }
}
