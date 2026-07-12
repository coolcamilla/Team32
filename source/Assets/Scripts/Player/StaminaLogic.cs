using System;
using System.Diagnostics;

public class StaminaLogic
{
    public float MaxStamina { get; set; }
    public float CurrentStamina { get; private set; }
    public float RegenCoefficent { get; private set; }
    public float BaseDrainRate { get; private set; }

    public float DrainMultiplier { get; set; } = 1f;
    public float RegenMultiplier { get; set; } = 1f;

    public bool IsExhausted => CurrentStamina <= 0f;

    public event Action<float, float> OnValueChanged;
    public event Action OnDeath;

    public StaminaLogic(float maxStamina, float regenCoefficient, float baseDrainRate)
    {
        MaxStamina = maxStamina;
        CurrentStamina = maxStamina;
        RegenCoefficent = regenCoefficient;
        BaseDrainRate = baseDrainRate;
    }

    public void Drain(float deltaTime)
    {
        if (CurrentStamina <= 0f) return;

        CurrentStamina -= BaseDrainRate * DrainMultiplier * deltaTime;

        if (CurrentStamina < 0f)
        {
            CurrentStamina = 0f;
            OnValueChanged?.Invoke(CurrentStamina, MaxStamina);

            OnDeath?.Invoke();
            return;
        }
        OnValueChanged?.Invoke(CurrentStamina, MaxStamina);
    }

    public void Regenerate(float deltaTime)
    {
        if (CurrentStamina >= MaxStamina) return;

        CurrentStamina += (MaxStamina * RegenCoefficent) * RegenMultiplier * deltaTime;
        if (CurrentStamina > MaxStamina) CurrentStamina = MaxStamina;

        OnValueChanged?.Invoke(CurrentStamina, MaxStamina);
    }

    public bool CanStartClimbing(float requiredStamina = 1f)
    {
        return CurrentStamina >= requiredStamina;
    }

    public void ResetStamina()
    {
        CurrentStamina = MaxStamina;
        OnValueChanged?.Invoke(CurrentStamina, MaxStamina);
    }
}
