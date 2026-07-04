using UnityEngine;
using UnityEngine.UI;
using System;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] private PlayerStamina _playerStamina;
    [SerializeField] private Slider _staminaSlider;
    [SerializeField] private float _smoothTime = 0.15f; // Время сглаживания

    private float _targetValue;

    private void Awake()
    {
        if (_playerStamina != null)
            _playerStamina.OnStaminaChanged += UpdateTargetValue;
    }

    private void Start()
    {
        if (_playerStamina != null)
        {
            _targetValue = _playerStamina.CurrentStamina;
            _staminaSlider.maxValue = _playerStamina.MaxStamina;
            _staminaSlider.value = _targetValue;
        }
    }

    private void Update()
    {
        if (_staminaSlider != null)
        {
            _staminaSlider.value = Mathf.Lerp(_staminaSlider.value, _targetValue, Time.deltaTime / _smoothTime);
        }
    }

    private void UpdateTargetValue(float current, float max)
    {
        _targetValue = current;
        if (_staminaSlider != null) _staminaSlider.maxValue = max;
    }

    private void OnDestroy()
    {
        if (_playerStamina != null)
            _playerStamina.OnStaminaChanged -= UpdateTargetValue;
    }
}