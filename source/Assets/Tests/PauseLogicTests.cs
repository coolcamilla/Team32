using NUnit.Framework;

public class PauseLogicTests
{
    [Test]
    public void InitialState_IsNotPaused()
    {
        PauseLogic logic = new PauseLogic();

        Assert.IsFalse(logic.IsPaused, "Initially pause must be turned off.");
    }

    [Test]
    public void TogglePause_FromNotPaused_BecomePaused()
    {
        PauseLogic logic = new PauseLogic();

        logic.TogglePause();

        Assert.IsTrue(logic.IsPaused, "Pause must be turn on.");
    }

    [Test]
    public void TogglePause_FromPaused_BecomeNotPaused()
    {
        PauseLogic logic = new PauseLogic();
        logic.TogglePause();

        logic.TogglePause();

        Assert.IsFalse(logic.IsPaused, "Pause must be turn off.");
    }

    [Test]
    public void Pause_WhenCalled_InvokesOnPausedEvent()
    {
        PauseLogic logic = new PauseLogic();
        bool eventWasCalled = false;
        logic.OnPaused += () => { eventWasCalled = true; };

        logic.Pause();

        Assert.IsTrue(eventWasCalled, "Event OnPaused must invoke on pause.");
        Assert.IsTrue(logic.IsPaused);
    }

    [Test]
    public void Resume_WhenCalled_InvokesOnResumedEvent()
    {
        PauseLogic logic = new PauseLogic();
        logic.Pause(); 

        bool eventWasCalled = false;
        logic.OnResumed += () => { eventWasCalled = true; };

        logic.Resume();

        Assert.IsTrue(eventWasCalled, "Event OnResumed must invoke when paused.");
        Assert.IsFalse(logic.IsPaused);
    }

    [Test]
    public void Pause_WhenAlreadyPaused_DoesNotInvokeEventAgain()
    {
        PauseLogic logic = new PauseLogic();
        logic.Pause(); 

        int callCount = 0;
        logic.OnPaused += () => { callCount++; };

        logic.Pause();

        Assert.AreEqual(0, callCount, "Event should not be invoke if the pause is already enabled.");
    }
}
