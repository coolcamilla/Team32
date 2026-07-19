using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerStamina : MonoBehaviour
{
    [Header("Stamina Settings")]
    [SerializeField] private float _maxStamina = 10f;
    [SerializeField] private float _regenCoefficient = 0.2f;
    [SerializeField] private float _drainRate = 1f;

    public static event UnityAction<bool> OnStaminaStateChange;

    public StaminaLogic Logic { get; private set; }

    public float CurrentStamina => Logic.CurrentStamina;
    public float MaxStamina => Logic.MaxStamina;

    public event Action<float, float> OnStaminaChanged;

    private void Awake()
    {
        Logic = new StaminaLogic(_maxStamina, _regenCoefficient, _drainRate);
        Logic.OnValueChanged += (current, max) => OnStaminaChanged?.Invoke(current, max);
    }

    private void Update()
    {
        OnStaminaStateChange?.Invoke(Logic.CurrentStamina <= Logic.MaxStamina * 0.4f);
    }

    public void Drain(float deltaTime) => Logic.Drain(deltaTime);
    public void Regenerate(float deltaTime) => Logic.Regenerate(deltaTime);
    public bool CanClimb() => Logic.CanStartClimbing(1f);

    public void SetDrainMultiplier(float multiplier) => Logic.DrainMultiplier -= multiplier;
    public void SetRegenMultiplier(float multiplier) => Logic.RegenMultiplier += multiplier;
    public void ModifyMaxStamina(float newMax) => Logic.MaxStamina = newMax;

    public void Respawn() => Logic.ResetStamina();

    public void Upgrade()
    {
        ModifyMaxStamina(MaxStamina + 5);
        SetRegenMultiplier((float)0.05);
    }
}
