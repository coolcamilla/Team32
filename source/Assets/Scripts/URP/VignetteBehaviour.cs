using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; 

[RequireComponent(typeof(Volume))]
public class VignetteBeahviour : MonoBehaviour
{
    [SerializeField] private float _maxIntensity = 0.7f;

    [SerializeField] private float _pulseSpeed = 3f;

    private Volume _volume;
    private Vignette _vignette;
    private bool _isActive = false;
    private float _timer = 0f;

    private void Awake()
    {
        _volume = GetComponent<Volume>();

        if (_volume.profile.TryGet(out Vignette vignette))
        {
            _vignette = vignette;

            _vignette.intensity.value = 0f;
            _vignette.smoothness.value = 0.3f;
        }

        PlayerStamina.OnStaminaStateChange += SetLowHealthState;
    }


    private void Update()
    {
        if (!_isActive || _vignette == null) return;

        _timer += Time.deltaTime * _pulseSpeed;

        float safeTime = Mathf.Repeat(_timer, Mathf.PI * 2f);

        float smoothWave = (Mathf.Sin(safeTime) + 1f) / 2f;

        _vignette.intensity.value = smoothWave * _maxIntensity;
    }

    public void ActivateLowHealth()
    {
        _isActive = true;
    }

    public void DeactivateLowHealth()
    {
        _isActive = false;

        if (_vignette != null)
        {
            _vignette.intensity.value = 0f;
        }
    }

    public void SetLowHealthState(bool isLowHealth)
    {
        if (isLowHealth) ActivateLowHealth();
        else DeactivateLowHealth();
    }
}