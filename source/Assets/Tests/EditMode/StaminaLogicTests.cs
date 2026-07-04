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
}
