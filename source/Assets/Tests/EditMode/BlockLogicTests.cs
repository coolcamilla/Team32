using NUnit.Framework;
using UnityEngine;

/// <summary>
/// EditMode unit tests for BlockBehaviourLogic - plain C#, no scene dependency.
///
/// Uses only the test configurator methods that actually exist on BlockTypeData
/// and Item (ConfigureForUnsuccessfulDamageTest, ConfigureForDropTest,
/// ConfigureToNotDefaultForTesting) rather than attempting to set MaxHp/MinDamage
/// directly - those are read-only computed properties backed by private
/// SerializeField data with no public setter.
/// </summary>
public class BlockLogicTests
{
    // Default BlockTypeData (no configurator called): MaxHp = 3, MinDamage = 0, empty drop table.
    // Default Item (no configurator called): Damage = 1f, Cooldown = 0.45f, Stackable = true.

    [Test]
    public void Constructor_SetsCurrentHpToMaxHp_UsingDefaultBlockData()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>();

        var logic = new BlockBehaviourLogic(data);

        Assert.AreEqual(3f, logic.CurrentHp); // default MaxHp = 3
        Assert.AreEqual(data, logic.BlockData);
    }

    [Test]
    public void IsItemSuitable_TrueWhenDamageMeetsMinDamage_UsingDefaults()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>(); // MinDamage = 0
        var logic = new BlockBehaviourLogic(data);
        var item = ScriptableObject.CreateInstance<Item>(); // Damage = 1f, 1f >= 0

        Assert.IsTrue(logic.IsItemSuitable(item));
    }

    [Test]
    public void IsItemSuitable_FalseWhenDamageBelowMinDamage()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>();
        data.ConfigureForUnsuccessfulDamageTest(); // MaxHp = 100, MinDamage = 50
        var logic = new BlockBehaviourLogic(data);
        var item = ScriptableObject.CreateInstance<Item>();
        item.ConfigureToNotDefaultForTesting(); // Damage = 15f, still well below MinDamage = 50

        Assert.IsFalse(logic.IsItemSuitable(item));
    }

    [Test]
    public void TryTakeDamage_ReturnsTrueAndReducesHp_UsingDefaults()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>(); // MaxHp = 3, MinDamage = 0
        var logic = new BlockBehaviourLogic(data);
        var item = ScriptableObject.CreateInstance<Item>(); // Damage = 1f

        bool result = logic.TryTakeDamage(item);

        Assert.IsTrue(result);
        Assert.AreEqual(2f, logic.CurrentHp, 0.0001f); // 3 - 1
    }

    [Test]
    public void TryTakeDamage_ReturnsFalseAndDoesNotReduceHp_WhenItemNotSuitable()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>();
        data.ConfigureForUnsuccessfulDamageTest(); // MaxHp = 100, MinDamage = 50
        var logic = new BlockBehaviourLogic(data);
        var item = ScriptableObject.CreateInstance<Item>();
        item.ConfigureToNotDefaultForTesting(); // Damage = 15f, below MinDamage = 50

        bool result = logic.TryTakeDamage(item);

        Assert.IsFalse(result);
        Assert.AreEqual(100f, logic.CurrentHp);
    }

    [Test]
    public void IsDestroyed_FalseWhileHpAboveZero_UsingDefaults()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>(); // MaxHp = 3
        var logic = new BlockBehaviourLogic(data);

        Assert.IsFalse(logic.IsDestroyed());
    }

    [Test]
    public void IsDestroyed_TrueWhenHpReachesExactlyZero_UsingDropTestConfig()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>();
        data.ConfigureForDropTest(); // MaxHp = 1, MinDamage = 0
        var logic = new BlockBehaviourLogic(data);
        var item = ScriptableObject.CreateInstance<Item>(); // Damage = 1f, exactly enough

        logic.TryTakeDamage(item);

        Assert.IsTrue(logic.IsDestroyed()); // 1 - 1 = 0, and IsDestroyed is `<= 0`
    }

    [Test]
    public void CalculateDrops_ReturnsAllGuaranteedDrops_UsingDropTestConfig()
    {
        // ConfigureForDropTest() sets up three DropChance entries, each with chance = 1f
        // (Stick, Rock, Pebbles), meaning they are always included regardless of the
        // random roll - deterministic, no flaky randomness in this test.
        var data = ScriptableObject.CreateInstance<BlockTypeData>();
        data.ConfigureForDropTest();
        var logic = new BlockBehaviourLogic(data);

        var drops = logic.CalculateDrops();

        Assert.AreEqual(3, drops.Count,
            "ConfigureForDropTest sets up exactly 3 guaranteed (chance=1) drops.");
        CollectionAssert.Contains(drops, ItemType.Stick);
        CollectionAssert.Contains(drops, ItemType.Rock);
        CollectionAssert.Contains(drops, ItemType.Pebbles);
    }

    [Test]
    public void CalculateDrops_ReturnsEmptyList_WhenDropTableIsEmpty_UsingDefaults()
    {
        var data = ScriptableObject.CreateInstance<BlockTypeData>(); // empty drop table by default
        var logic = new BlockBehaviourLogic(data);

        var drops = logic.CalculateDrops();

        Assert.IsNotNull(drops);
        Assert.AreEqual(0, drops.Count);
    }
}
