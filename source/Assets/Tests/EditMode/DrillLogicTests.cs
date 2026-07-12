using NUnit.Framework;
using UnityEngine;

/// <summary>
/// EditMode unit tests for DrillLogic - plain C#, no scene dependency.
///
/// IMPORTANT LIMITATION: the exact numeric "Basic" tier values for Drill.Speed,
/// Engine.Speed/Power, FuelTank.Capacity, and Fuel.Energy were not confirmed from
/// source when these tests were written (only that SetBasic() configures them to
/// some fixed baseline). Tests here deliberately avoid hardcoding expected numeric
/// depth/energy values and instead assert relative/structural behavior - the same
/// approach used in StaminaLogicTests.cs for values not fully known in advance.
/// A test requiring exact depth-threshold-crossing (e.g. reaching the real 3.5m
/// NewLayerDepth, or a direct "IsStuck() blocks Tick()" test) is NOT included here,
/// since simulating it correctly requires knowing the real Speed/Power/Fuel.Energy
/// numbers to avoid an incorrect or infinitely-looping test - confirm those values
/// before adding that coverage, rather than including a test that doesn't actually
/// verify anything.
///
/// ASSUMPTION, not directly confirmed: Fuel is a ScriptableObject, consistent with
/// Drill/Engine/FuelTank all being constructed via `X.CreateInstance&lt;X&gt;()` in
/// DrillLogic's own constructor. If Fuel turns out to be a plain class instead,
/// change `ScriptableObject.CreateInstance&lt;Fuel&gt;()` below to `new Fuel()`.
/// </summary>
public class DrillLogicTests
{
    [Test]
    public void Constructor_StartsAtZeroDepth()
    {
        var logic = new DrillLogic();

        Assert.AreEqual(0f, logic.Depth);
    }

    [Test]
    public void Constructor_StartsWithZeroAvailableEnergy()
    {
        var logic = new DrillLogic();

        Assert.AreEqual(0f, logic.Energy);
    }

    [Test]
    public void Constructor_StartsWithEmptyFuelQueue()
    {
        var logic = new DrillLogic();

        Assert.AreEqual(0, logic.FuelCount);
    }

    [Test]
    public void Constructor_StartsWithBasicComponents_NotStuckAtZeroDepth()
    {
        var logic = new DrillLogic();

        // IsStuck() requires depth >= NewLayerDepth (3.5m) AND a Basic component -
        // at 0 depth, the drill should never be considered stuck regardless of tier.
        Assert.IsFalse(logic.IsStuck());
    }

    [Test]
    public void TryAddFuel_SucceedsWhileUnderCapacity_ThenFailsOnceFull()
    {
        var logic = new DrillLogic();
        int capacity = logic.CurrentFuelTank.Capacity;
        var fuel = ScriptableObject.CreateInstance<Fuel>();

        int successfulAdds = 0;
        while (logic.TryAddFuel(fuel))
        {
            successfulAdds++;
            if (successfulAdds > capacity + 5) break; // safety guard against an infinite loop
        }

        Assert.AreEqual(capacity, successfulAdds,
            "Number of successful fuel adds should exactly match the fuel tank's capacity.");
        Assert.AreEqual(capacity, logic.FuelCount);
    }

    [Test]
    public void TryAddFuel_OnceAtCapacity_ReturnsFalseAndDoesNotIncreaseCount()
    {
        var logic = new DrillLogic();
        var fuel = ScriptableObject.CreateInstance<Fuel>();
        int capacity = logic.CurrentFuelTank.Capacity;

        for (int i = 0; i < capacity; i++) logic.TryAddFuel(fuel);
        bool resultWhenFull = logic.TryAddFuel(fuel);

        Assert.IsFalse(resultWhenFull);
        Assert.AreEqual(capacity, logic.FuelCount,
            "FuelCount should not increase beyond capacity.");
    }

    [Test]
    public void TryProcessSecond_ReturnsFalse_WhenNoFuelAndNoStoredEnergy()
    {
        // With zero fuel and zero available energy, PrepareEnergy() has nothing to
        // burn, so ProcessSecond()'s `if (_availableEnergy < _power) return false;`
        // guard should trigger - assuming Power > 0 for a functioning Basic engine.
        var logic = new DrillLogic();

        // Tick enough to pass the internal 1-second timer threshold.
        logic.Tick(1f);
        bool result = logic.TryProcessSecond();

        Assert.IsFalse(result,
            "Should not be able to process a second of drilling with no fuel and no stored energy.");
        Assert.AreEqual(0f, logic.Depth,
            "Depth should not increase when TryProcessSecond fails.");
    }

    [Test]
    public void TryProcessSecond_ReturnsFalse_BeforeOneSecondHasAccumulated()
    {
        var logic = new DrillLogic();

        logic.Tick(0.5f); // less than the 1-second internal threshold
        bool result = logic.TryProcessSecond();

        Assert.IsFalse(result);
    }

    [Test]
    public void IsMarkPassed_FalseWhenDepthUnchanged()
    {
        var logic = new DrillLogic();

        // At construction, depth is 0 and no mark has been passed yet.
        Assert.IsFalse(logic.IsMarkPassed());
    }

    [Test]
    public void IsLayeNeedToBeUpdated_FalseAtZeroDepth()
    {
        var logic = new DrillLogic();

        Assert.IsFalse(logic.IsLayeNeedToBeUpdated(),
            "Should not need a layer update at 0 depth, well below the 3.5m threshold.");
    }
}