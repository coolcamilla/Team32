using NUnit.Framework;

/// <summary>
/// EditMode unit tests for StaminaLogic.
/// StaminaLogic has no UnityEngine scene dependency (plain C#, same pattern
/// as BlockBehaviourLogic per ADR-003), so it is testable via `new StaminaLogic(...)`
/// without a loaded scene, GameObject, or PlayMode.
/// </summary>
public class StaminaLogicTests
{
    private const float MaxStamina = 10f;
    private const float RegenCoefficient = 0.2f; // fraction of MaxStamina regenerated per second
    private const float DrainRate = 1f;          // stamina drained per second at multiplier 1

    private StaminaLogic CreateDefault()
    {
        return new StaminaLogic(MaxStamina, RegenCoefficient, DrainRate);
    }

    [Test]
    public void Constructor_SetsCurrentStaminaToMax()
    {
        var logic = CreateDefault();

        Assert.AreEqual(MaxStamina, logic.CurrentStamina);
        Assert.AreEqual(MaxStamina, logic.MaxStamina);
    }

    [Test]
    public void Constructor_DefaultMultipliersAreOne()
    {
        var logic = CreateDefault();

        Assert.AreEqual(1f, logic.DrainMultiplier);
        Assert.AreEqual(1f, logic.RegenMultiplier);
    }

    [Test]
    public void IsExhausted_FalseWhenStaminaAboveZero()
    {
        var logic = CreateDefault();

        Assert.IsFalse(logic.IsExhausted);
    }

    [Test]
    public void Drain_ReducesCurrentStaminaByRateTimesDeltaTime()
    {
        var logic = CreateDefault();

        logic.Drain(2f); // 1 stamina/sec * 2 sec = 2 stamina drained

        Assert.AreEqual(MaxStamina - 2f, logic.CurrentStamina, 0.0001f);
    }

    [Test]
    public void Drain_RespectsDrainMultiplier()
    {
        var logic = CreateDefault();
        logic.DrainMultiplier = 3f;

        logic.Drain(1f); // 1 stamina/sec * 3x multiplier * 1 sec = 3 stamina drained

        Assert.AreEqual(MaxStamina - 3f, logic.CurrentStamina, 0.0001f);
    }

    [Test]
    public void Drain_ClampsAtZero_DoesNotGoNegative()
    {
        var logic = CreateDefault();

        logic.Drain(100f); // far more than available stamina

        Assert.AreEqual(0f, logic.CurrentStamina);
    }

    [Test]
    public void Drain_WhenAlreadyAtZero_StaysAtZero_DoesNotInvokeEvent()
    {
        var logic = CreateDefault();
        logic.Drain(100f); // exhaust it first
        bool eventFired = false;
        logic.OnValueChanged += (_, _) => eventFired = true;

        logic.Drain(1f); // guard clause: CurrentStamina <= 0f returns early

        Assert.AreEqual(0f, logic.CurrentStamina);
        Assert.IsFalse(eventFired,
            "OnValueChanged should not fire when Drain is called while already at zero, " +
            "since StaminaLogic.Drain returns early in that case.");
    }

    [Test]
    public void Drain_InvokesOnValueChanged_WithCurrentAndMax()
    {
        var logic = CreateDefault();
        float? reportedCurrent = null;
        float? reportedMax = null;
        logic.OnValueChanged += (current, max) =>
        {
            reportedCurrent = current;
            reportedMax = max;
        };

        logic.Drain(1f);

        Assert.AreEqual(MaxStamina - 1f, reportedCurrent, 0.0001f);
        Assert.AreEqual(MaxStamina, reportedMax);
    }

    [Test]
    public void Regenerate_IncreasesCurrentStaminaByMaxTimesCoefficientTimesDeltaTime()
    {
        var logic = CreateDefault();
        logic.Drain(5f); // bring it down to 5 first

        logic.Regenerate(1f); // 10 * 0.2 * 1 = 2 stamina regenerated

        Assert.AreEqual(7f, logic.CurrentStamina, 0.0001f);
    }

    [Test]
    public void Regenerate_RespectsRegenMultiplier()
    {
        var logic = CreateDefault();
        logic.Drain(5f);
        logic.RegenMultiplier = 2f;

        logic.Regenerate(1f); // 10 * 0.2 * 2x * 1 = 4 stamina regenerated

        Assert.AreEqual(9f, logic.CurrentStamina, 0.0001f);
    }

    [Test]
    public void Regenerate_ClampsAtMaxStamina_DoesNotExceedMax()
    {
        var logic = CreateDefault();
        logic.Drain(1f); // bring it slightly below max

        logic.Regenerate(100f); // far more than needed to refill

        Assert.AreEqual(MaxStamina, logic.CurrentStamina);
    }

    [Test]
    public void Regenerate_WhenAlreadyAtMax_StaysAtMax_DoesNotInvokeEvent()
    {
        var logic = CreateDefault(); // starts at MaxStamina already
        bool eventFired = false;
        logic.OnValueChanged += (_, _) => eventFired = true;

        logic.Regenerate(1f); // guard clause: CurrentStamina >= MaxStamina returns early

        Assert.AreEqual(MaxStamina, logic.CurrentStamina);
        Assert.IsFalse(eventFired,
            "OnValueChanged should not fire when Regenerate is called while already at max, " +
            "since StaminaLogic.Regenerate returns early in that case.");
    }

    [Test]
    public void CanStartClimbing_TrueWhenStaminaAtOrAboveRequiredAmount()
    {
        var logic = CreateDefault(); // CurrentStamina = 10

        Assert.IsTrue(logic.CanStartClimbing(1f));
        Assert.IsTrue(logic.CanStartClimbing(10f)); // exactly equal to current stamina
    }

    [Test]
    public void CanStartClimbing_FalseWhenStaminaBelowRequiredAmount()
    {
        var logic = CreateDefault();
        logic.Drain(9.5f); // CurrentStamina = 0.5

        Assert.IsFalse(logic.CanStartClimbing(1f));
    }

    [Test]
    public void CanStartClimbing_DefaultRequiredStaminaIsOne()
    {
        var logic = CreateDefault();
        logic.Drain(9.5f); // CurrentStamina = 0.5, below the default requirement of 1

        Assert.IsFalse(logic.CanStartClimbing());
    }

    [Test]
    public void ModifyingMaxStamina_UpdatesMaxStaminaProperty()
    {
        var logic = CreateDefault();

        logic.MaxStamina = 20f;

        Assert.AreEqual(20f, logic.MaxStamina);
    }

    [Test]
    public void IsExhausted_TrueOnlyWhenStaminaReachesExactlyZero()
    {
        var logic = CreateDefault();
        logic.Drain(9.99f);
        Assert.IsFalse(logic.IsExhausted, "Should not be exhausted while stamina remains above zero.");

        logic.Drain(1f); // clamps to exactly 0
        Assert.IsTrue(logic.IsExhausted);
    }
    [Test]
    public void Drain_WhenReachingExactlyZeroForTheFirstTime_InvokesOnDeath()
    {
        var logic = CreateDefault();
        bool deathFired = false;
        logic.OnDeath += () => deathFired = true;

        logic.Drain(100f); // far more than available, clamps to exactly 0

        Assert.IsTrue(deathFired,
            "OnDeath should fire the first time CurrentStamina clamps to exactly 0.");
    }

    [Test]
    public void Drain_WhileStaminaRemainsAboveZero_DoesNotInvokeOnDeath()
    {
        var logic = CreateDefault();
        bool deathFired = false;
        logic.OnDeath += () => deathFired = true;

        logic.Drain(1f); // only drains 1 of 10, stays above 0

        Assert.IsFalse(deathFired);
    }

    [Test]
    public void Drain_WhenAlreadyAtZero_DoesNotInvokeOnDeathAgain()
    {
        // StaminaLogic.Drain has an early-return guard (`if (CurrentStamina <= 0f) return;`)
        // at the very top, before the OnDeath-triggering code even runs - so calling
        // Drain again while already at 0 should not re-fire OnDeath.
        var logic = CreateDefault();
        logic.Drain(100f); // first death, clamps to 0
        bool deathFiredAgain = false;
        logic.OnDeath += () => deathFiredAgain = true;

        logic.Drain(1f); // called again while already at 0

        Assert.IsFalse(deathFiredAgain,
            "OnDeath should not fire again from a Drain call while already at 0 stamina, " +
            "since Drain's early-return guard exits before reaching the OnDeath-invoking code.");
    }

    [Test]
    public void ResetStamina_SetsCurrentStaminaBackToMax()
    {
        var logic = CreateDefault();
        logic.Drain(100f); // exhaust it, e.g. simulating a death

        logic.ResetStamina();

        Assert.AreEqual(MaxStamina, logic.CurrentStamina);
    }

    [Test]
    public void ResetStamina_InvokesOnValueChanged()
    {
        var logic = CreateDefault();
        logic.Drain(5f);
        bool eventFired = false;
        logic.OnValueChanged += (_, _) => eventFired = true;

        logic.ResetStamina();

        Assert.IsTrue(eventFired,
            "ResetStamina should notify listeners (e.g. a stamina bar UI) that the value changed.");
    }

    [Test]
    public void ResetStamina_AfterDeath_AllowsOnDeathToFireAgainOnASubsequentFullDrain()
    {
        // Real gameplay cycle: die -> respawn (ResetStamina) -> die again should be
        // possible. This confirms ResetStamina() genuinely clears the "already at
        // zero" guard state, not just the numeric value.
        var logic = CreateDefault();
        int deathCount = 0;
        logic.OnDeath += () => deathCount++;

        logic.Drain(100f);   // first death
        logic.ResetStamina(); // respawn
        logic.Drain(100f);   // second death

        Assert.AreEqual(2, deathCount,
            "OnDeath should fire once per full drain-to-zero cycle, including after a respawn.");
    }
}
