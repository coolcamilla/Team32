using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/// <summary>
/// EditMode unit tests for CraftLogic - plain C#, no scene dependency.
///
/// CraftLogic's real constructor accepts any Dictionary&lt;ItemType, Item&gt; converter -
/// in production this is TypeToItemData.Converter (Resources-loaded), but tests can
/// pass a custom in-memory dictionary instead, avoiding any dependency on Resources
/// assets or a loaded scene.
///
/// KNOWN LIMITATION, documented rather than hidden: Item.ConfigureItemForCraftTestResult()
/// sets the crafted item's Type to ItemType.Test (value 1). InventoryLogic.TryAddItem
/// rejects any item with (int)Type &lt; 300. This means the existing test configurator
/// produces a "craftable" item that CraftLogic will successfully process (materials
/// spent, TryCraft returns true) but which is never actually added to the inventory -
/// see CraftedItem_UsingTestConfigurator_IsNeverActuallyStored below, which asserts
/// this real (and arguably unintended) behavior rather than assuming success.
/// </summary>
public class CraftLogicTests
{
    private Item _materialItem; // ItemType.Stick (300), stackable
    private Item _resultItem;   // ItemType.Test (1), recipe requires 2x Stick
    private Dictionary<ItemType, Item> _converter;
    private InventoryLogic _inventoryLogic;
    private CraftLogic _craftLogic;

    [SetUp]
    public void SetUp()
    {
        _materialItem = ScriptableObject.CreateInstance<Item>();
        _materialItem.ConfigureItemForCraftTestMaterial(); // Type = Stick (300)

        _resultItem = ScriptableObject.CreateInstance<Item>();
        _resultItem.ConfigureItemForCraftTestResult(); // Type = Test (1), Recipe = 2x Stick

        _converter = new Dictionary<ItemType, Item>
        {
            { ItemType.Stick, _materialItem },
            { ItemType.Test, _resultItem }
        };

        _inventoryLogic = new InventoryLogic(slotCount: 5, maxStackSize: 10);
        _craftLogic = new CraftLogic(_inventoryLogic, _converter);
    }

    [Test]
    public void IsPossibleToCraft_FalseWhenNoMaterials()
    {
        Assert.IsFalse(_craftLogic.IsPossibleToCraft(_resultItem));
    }

    [Test]
    public void IsPossibleToCraft_FalseWhenInsufficientMaterials()
    {
        _inventoryLogic.TryAddItem(_materialItem); // only 1, recipe requires 2

        Assert.IsFalse(_craftLogic.IsPossibleToCraft(_resultItem));
    }

    [Test]
    public void IsPossibleToCraft_TrueWhenExactlyEnoughMaterials()
    {
        _inventoryLogic.TryAddItem(_materialItem);
        _inventoryLogic.TryAddItem(_materialItem); // 2 sticks, exactly the recipe requirement

        Assert.IsTrue(_craftLogic.IsPossibleToCraft(_resultItem));
    }

    [Test]
    public void TryCraft_InsufficientMaterials_ReturnsFalseAndSpendsNothing()
    {
        _inventoryLogic.TryAddItem(_materialItem); // only 1

        bool result = _craftLogic.TryCraft(ItemType.Test);

        Assert.IsFalse(result);
        Assert.IsTrue(_inventoryLogic.IsEnough(_materialItem, 1),
            "A failed craft attempt should not spend any materials.");
    }

    [Test]
    public void TryCraft_SufficientMaterials_ReturnsTrueAndSpendsExactRequiredAmount()
    {
        _inventoryLogic.TryAddItem(_materialItem);
        _inventoryLogic.TryAddItem(_materialItem);
        _inventoryLogic.TryAddItem(_materialItem); // 3 sticks, 1 more than required

        bool result = _craftLogic.TryCraft(ItemType.Test);

        Assert.IsTrue(result);
        Assert.IsTrue(_inventoryLogic.IsEnough(_materialItem, 1),
            "Exactly 2 of the 3 available sticks should be spent, leaving 1.");
        Assert.IsFalse(_inventoryLogic.IsEnough(_materialItem, 2));
    }

    [Test]
    public void TryCraft_UnknownItemType_ThrowsKeyNotFoundException()
    {
        // CraftLogic.TryCraft does a direct dictionary lookup (_converter[type]) with
        // no existence check, so an unregistered type throws rather than failing
        // gracefully. Documenting this as real, current behavior.
        Assert.Throws<KeyNotFoundException>(() => _craftLogic.TryCraft(ItemType.Coal));
    }

    [Test]
    public void CraftedItem_UsingTestConfigurator_IsNeverActuallyStored()
    {
        // See class-level comment: ItemType.Test (1) is below InventoryLogic's
        // TryAddItem threshold of 300, so the crafted item is never added to
        // inventory even though TryCraft reports success and materials are spent.
        // This test documents that real, current behavior rather than assuming
        // the crafted item ends up in the inventory.
        _inventoryLogic.TryAddItem(_materialItem);
        _inventoryLogic.TryAddItem(_materialItem);

        bool craftResult = _craftLogic.TryCraft(ItemType.Test);

        Assert.IsTrue(craftResult, "TryCraft reports success...");
        Assert.IsFalse(_inventoryLogic.IsEnough(_resultItem, 1),
            "...but the crafted item is NOT actually present in the inventory, " +
            "because its ItemType.Test value (1) is below the 300 threshold " +
            "InventoryLogic.TryAddItem requires. This may be worth a team discussion.");
    }
}
