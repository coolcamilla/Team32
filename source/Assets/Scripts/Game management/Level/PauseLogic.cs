using System;

public class PauseLogic
{
    public bool IsPaused { get; private set; }

    public event Action OnPaused;
    public event Action OnResumed;

    public PauseLogic()
    {
        IsPaused = false;
    }

    public void TogglePause()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (IsPaused) return;

        IsPaused = true;
        OnPaused?.Invoke();
    }

    public void Resume()
    {
        if (!IsPaused) return;

        IsPaused = false;
        OnResumed?.Invoke();
    }
}