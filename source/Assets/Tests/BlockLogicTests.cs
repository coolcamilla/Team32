using NUnit.Framework;
using UnityEngine;

public class BlockLogicTests
{
    [Test]
    public void BlockTakesDamageWhenInstrumentIsStrongEnough()
    {
        //Basic HP and damage values for the test
        //MaxHP = 3
        //MinDamage = 0
        BlockTypeData testData = ScriptableObject.CreateInstance<BlockTypeData>();

        //Basic damage value for the test
        //Damage = 1
        Item testItem = Item.CreateInstance<Item>();

        BlockBehaviourLogic logic = new BlockBehaviourLogic(testData);

        bool damageApplied = logic.TryTakeDamage(testItem);

        Assert.IsTrue(damageApplied, "The pickaxe should have damaged the block.");
        Assert.AreEqual(2, logic.CurrentHp, $"HP should be reduced by {testItem.Damage}.");
    }

    [Test]
    public void BlockIgnoresDamageWhenInstrumentIsTooWeak()
    {
        //Basic HP and damage values for the test
        //MaxHP = 3
        //MinDamage = 0
        BlockTypeData testData = ScriptableObject.CreateInstance<BlockTypeData>();

        // This sets MinDamage to a value higher than the weak item's damage
        //MaxHP = 100
        //MinDamage = 50
        testData.ConfigureForUnsuccessfulDamageTest(); 

        //Basic damage value for the test
        //Damage = 1
        Item weakHand = Item.CreateInstance<Item>();

        BlockBehaviourLogic logic = new BlockBehaviourLogic(testData);


        bool damageApplied = logic.TryTakeDamage(weakHand);


        Assert.IsFalse(damageApplied, "Weak item should not damage the block.");
        Assert.AreEqual(100, logic.CurrentHp, "HP should remain unchanged.");
    }

    [Test]
    public void BlockDropsLootWhenHpReachesZero()
    {
        //Basic HP and damage values for the test
        //MaxHP = 3
        //MinDamage = 0
        BlockTypeData testData = ScriptableObject.CreateInstance<BlockTypeData>();
        
        // Assuming GetTable is set up with a 100% drop chance for the test
        //MaxHP = 1
        //MinDamage = 0
        //Stick, Rock, and Pebbles inside droptable with 1.0 chance each
        testData.ConfigureForDropTest();

        //Basic damage value for the test
        //Damage = 1
        Item testItem = Item.CreateInstance<Item>();


        BlockBehaviourLogic logic = new BlockBehaviourLogic(testData);


        logic.TryTakeDamage(testItem); // This should kill the block
        var drops = logic.CalculateDrops();


        Assert.IsTrue(logic.IsDestroyed(), "Block HP should be 0 or less.");
        Assert.IsNotEmpty(drops, "Block should have dropped Stick, Rock, and Pebbles");
    }
}