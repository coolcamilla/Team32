using TMPro;
using UnityEngine;

public class DepthCounter : MonoBehaviour
{
    private const float BLOCK_SIZE = 2.5f;
    private const float BLOCKS_PER_METER = 12.5f / 3.5f;

    private Transform _playerTransform;
    private TextMeshProUGUI _depthRenderer;

    private float _startingOffset;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _depthRenderer = GetComponent<TextMeshProUGUI>();

        _startingOffset = _playerTransform.position.y;
    }

    private void Update()
    {
        float depth = (_playerTransform.position.y - _startingOffset) / BLOCK_SIZE / BLOCKS_PER_METER * -1;
        _depthRenderer.SetText($"Depth: {(int)depth} m.");
    }
}
