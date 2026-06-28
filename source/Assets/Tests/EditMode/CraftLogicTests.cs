using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CraftLogicTests
{
    [Test]
    public void CraftSucceedsWhenEnoughMaterials()
    {
        var inventory = new InventoryLogic(slotCount: 10, maxStackSize: 16);

        Item stick = ScriptableObject.CreateInstance<Item>();
        Item testItem = ScriptableObject.CreateInstance<Item>();

        stick.ConfigureItemForCraftTestMaterial();
        testItem.ConfigureItemForCraftTestResult();
        
        //Pseudo type to item converter
        var database = new Dictionary<ItemType, Item>
    {
        { ItemType.Stick, stick },
        { ItemType.Test, testItem }
    };

        CraftLogic craftLogic = new CraftLogic(inventory, database);

        //Adding 3 sticks to inventory
        inventory.TryAddItem(stick);
        inventory.TryAddItem(stick);
        inventory.TryAddItem(stick);

        bool result = craftLogic.TryCraft(ItemType.Test);

        Assert.IsTrue(result, "Craft should succeed if materials are present.");
        Assert.IsNotNull(inventory.Slots[1], "Test item should be in the second slot.");
        Assert.AreEqual(1, inventory.Slots[0].Count, "Only one stick should remain in the first slot");
    }
}
