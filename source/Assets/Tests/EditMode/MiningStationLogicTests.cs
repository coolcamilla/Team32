using NUnit.Framework;

/// <summary>
/// EditMode unit tests for MiningStationLogic - plain C#, no scene dependency.
/// Real source confirmed: Tick(deltaTime) accumulates a timer and returns true
/// (resetting the timer to exactly 0, not carrying over any overflow) once the
/// timer reaches the configured mining interval.
/// </summary>
public class MiningStationLogicTests
{
    [Test]
    public void Tick_ReturnsFalse_WhenIntervalNotYetReached()
    {
        var logic = new MiningStationLogic(miningInterval: 10f);

        bool result = logic.Tick(5f);

        Assert.IsFalse(result);
    }

    [Test]
    public void Tick_ReturnsTrue_WhenIntervalExactlyReached()
    {
        var logic = new MiningStationLogic(miningInterval: 10f);

        bool result = logic.Tick(10f);

        Assert.IsTrue(result);
    }

    [Test]
    public void Tick_ReturnsTrue_WhenIntervalExceeded()
    {
        var logic = new MiningStationLogic(miningInterval: 10f);

        bool result = logic.Tick(15f);

        Assert.IsTrue(result);
    }

    [Test]
    public void Tick_ResetsTimerToZero_NotToTheOverflowAmount()
    {
        // Real behavior: `_timer = 0f;` on trigger, not `_timer -= _miningInterval`.
        // This means overshoot deltaTime is discarded, not carried into the next
        // interval - worth documenting since a very large single deltaTime jump
        // only ever triggers one production cycle, never multiple.
        var logic = new MiningStationLogic(miningInterval: 10f);

        logic.Tick(25f); // triggers once, discards the extra 15f overshoot

        bool immediatelyAfter = logic.Tick(0.01f);
        Assert.IsFalse(immediatelyAfter,
            "Timer should have reset to 0 on trigger, not retained overflow from the previous tick.");
    }

    [Test]
    public void Tick_AccumulatesAcrossMultipleCalls_BeforeTriggering()
    {
        var logic = new MiningStationLogic(miningInterval: 10f);

        Assert.IsFalse(logic.Tick(4f));
        Assert.IsFalse(logic.Tick(4f));
        Assert.IsTrue(logic.Tick(2f)); // 4 + 4 + 2 = 10, reaches the interval
    }

    [Test]
    public void Tick_DoesNotTriggerAgain_UntilFullIntervalAccumulatesAnew()
    {
        var logic = new MiningStationLogic(miningInterval: 10f);

        Assert.IsTrue(logic.Tick(10f));  // first trigger
        Assert.IsFalse(logic.Tick(9f));  // not yet enough for a second trigger
        Assert.IsTrue(logic.Tick(1f));   // now enough
    }
}