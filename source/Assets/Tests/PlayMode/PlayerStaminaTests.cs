using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

/// <summary>
/// PlayMode integration tests for PlayerStamina.
///
/// PlayerStamina has [RequireComponent(typeof(PlayerMovement))], and
/// PlayerMovement.Awake() depends on scene-specific setup (a "Collider/Feet"
/// child object, a wired PlayerManager with an initialized Input property, etc.)
/// that only exists on the real Player GameObject in the Level scene. Adding
/// PlayerStamina to an isolated test GameObject would force-add PlayerMovement
/// via RequireComponent and throw a NullReferenceException in its Awake().
///
/// These tests therefore use the already-initialized PlayerStamina instance
/// found on the real Player GameObject after the Level scene has loaded,
/// exercising the public wrapper API (not StaminaLogic directly - that has
/// its own EditMode unit tests in StaminaLogicTests.cs).
/// </summary>
public class PlayerStaminaTests
{
    private PlayerStamina _stamina;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        if (SceneManager.GetActiveScene().name != "Level")
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
            yield return null;
            yield return null;
        }
        else
        {
            yield return null;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Setup FAIL: no GameObject tagged 'Player' found in the Level scene.");

        _stamina = player.GetComponent<PlayerStamina>();
        Assert.IsNotNull(_stamina, "Setup FAIL: Player GameObject has no PlayerStamina component.");

        // Reset to a known state before each test so tests don't leak state into each other,
        // since the scene (and therefore this component instance) is loaded once per session.
        _stamina.SetDrainMultiplier(1f);
        _stamina.SetRegenMultiplier(1f);
        _stamina.Regenerate(9999f); // force back to full stamina
    }

    [UnityTest]
    public IEnumerator PlayerStamina_OnSceneLoad_LogicIsInitialized()
    {
        yield return null;

        Assert.IsNotNull(_stamina.Logic,
            "PlayerStamina.Logic should be initialized by Awake().");
        Assert.Greater(_stamina.MaxStamina, 0f,
            "MaxStamina should be a positive value from the Inspector-configured field.");
    }

    [UnityTest]
    public IEnumerator Drain_ReducesCurrentStamina()
    {
        float before = _stamina.CurrentStamina;

        _stamina.Drain(1f);
        yield return null;

        Assert.Less(_stamina.CurrentStamina, before,
            "CurrentStamina should decrease after calling Drain().");
    }

    [UnityTest]
    public IEnumerator Regenerate_IncreasesCurrentStamina_AfterDrain()
    {
        _stamina.Drain(5f);
        float afterDrain = _stamina.CurrentStamina;
        yield return null;

        _stamina.Regenerate(1f);
        yield return null;

        Assert.Greater(_stamina.CurrentStamina, afterDrain,
            "CurrentStamina should increase after Regenerate() following a Drain().");
    }

    [UnityTest]
    public IEnumerator CanClimb_FalseWhenExhausted()
    {
        _stamina.Drain(9999f); // fully exhaust
        yield return null;

        Assert.IsFalse(_stamina.CanClimb(),
            "CanClimb() should be false when stamina is fully drained.");
    }

    [UnityTest]
    public IEnumerator CanClimb_TrueWhenStaminaAvailable()
    {
        _stamina.Regenerate(9999f); // ensure full
        yield return null;

        Assert.IsTrue(_stamina.CanClimb(),
            "CanClimb() should be true when stamina is at maximum.");
    }

    [UnityTest]
    public IEnumerator OnStaminaChanged_FiresWithCurrentAndMaxStamina_OnDrain()
    {
        float? reportedCurrent = null;
        float? reportedMax = null;
        System.Action<float, float> handler = (current, max) =>
        {
            reportedCurrent = current;
            reportedMax = max;
        };
        _stamina.OnStaminaChanged += handler;

        _stamina.Drain(1f);
        yield return null;

        _stamina.OnStaminaChanged -= handler;

        Assert.IsTrue(reportedCurrent.HasValue,
            "OnStaminaChanged should fire when Drain() changes stamina.");
        Assert.AreEqual(_stamina.CurrentStamina, reportedCurrent.Value, 0.0001f);
        Assert.AreEqual(_stamina.MaxStamina, reportedMax.Value, 0.0001f);
    }

    [UnityTest]
    public IEnumerator SetDrainMultiplier_IncreasesDrainAmount()
    {
        _stamina.Regenerate(9999f);
        _stamina.SetDrainMultiplier(1f);
        float baseline = _stamina.CurrentStamina;
        _stamina.Drain(1f);
        float drainedNormal = baseline - _stamina.CurrentStamina;
        yield return null;

        _stamina.Regenerate(9999f);
        _stamina.SetDrainMultiplier(3f);
        baseline = _stamina.CurrentStamina;
        _stamina.Drain(1f);
        float drainedTripled = baseline - _stamina.CurrentStamina;
        yield return null;

        Assert.Greater(drainedTripled, drainedNormal,
            "A higher drain multiplier should drain more stamina for the same deltaTime.");
    }

    [UnityTest]
    public IEnumerator SetRegenMultiplier_IncreasesRegenAmount()
    {
        _stamina.SetRegenMultiplier(1f);
        _stamina.Drain(5f);
        float baseline = _stamina.CurrentStamina;
        _stamina.Regenerate(1f);
        float regenNormal = _stamina.CurrentStamina - baseline;
        yield return null;

        _stamina.Drain(5f);
        _stamina.SetRegenMultiplier(3f);
        baseline = _stamina.CurrentStamina;
        _stamina.Regenerate(1f);
        float regenTripled = _stamina.CurrentStamina - baseline;
        yield return null;

        Assert.Greater(regenTripled, regenNormal,
            "A higher regen multiplier should regenerate more stamina for the same deltaTime.");
    }

    [UnityTest]
    public IEnumerator ModifyMaxStamina_UpdatesMaxStaminaProperty()
    {
        float original = _stamina.MaxStamina;

        _stamina.ModifyMaxStamina(original + 5f);
        yield return null;

        Assert.AreEqual(original + 5f, _stamina.MaxStamina, 0.0001f);

        // Restore original state so later tests/sessions aren't affected.
        _stamina.ModifyMaxStamina(original);
    }
}
