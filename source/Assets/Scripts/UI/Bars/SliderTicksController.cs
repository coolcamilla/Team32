using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTicksController : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private GameObject _tickPrefab;
    [SerializeField] private float _stepSize = 20f;

    private float _previousMaxSize;

    private List<GameObject> _spawnedTicks = new List<GameObject>();

    private void Start()
    {
        _previousMaxSize = _slider.maxValue;
        UpdateTicks(_slider.maxValue);
    }

    private void Update()
    {
        if (_previousMaxSize != _slider.maxValue)
        {
            UpdateTicks(_slider.maxValue);
        }
    }

    public void UpdateTicks(float newMaxValue)
    {
        ClearTicks();

        for (float currentValue = _stepSize; currentValue < newMaxValue; currentValue += _stepSize)
        {
            GameObject tick = Instantiate(_tickPrefab, transform);
            RectTransform rt = tick.GetComponent<RectTransform>();

            float percentage = currentValue / newMaxValue;

            rt.anchorMin = new Vector2(percentage, 0.5f);
            rt.anchorMax = new Vector2(percentage, 0.5f);

            rt.pivot = new Vector2(0.5f, 0.5f);

            rt.anchoredPosition = Vector2.zero;

            _spawnedTicks.Add(tick);
        }
    }

    private void ClearTicks()
    {
        foreach (var tick in _spawnedTicks)
        {
            if (tick != null) Destroy(tick);
        }
        _spawnedTicks.Clear();
    }
}