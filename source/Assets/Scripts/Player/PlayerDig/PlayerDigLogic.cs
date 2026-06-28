using UnityEngine;
using System;

public class PlayerDigLogic
{
    private static PlayerDigLogic _instance;

    private float _horizontalDirection;
    private float _verticalDirection;
    private float _timer;
    private PlayerManager _playerManager;

    public float HorizontalDirection => _horizontalDirection;
    public float VerticalDirection => _verticalDirection;

    public static PlayerDigLogic Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerDigLogic();
            }
            return _instance;
        }
    }
    private PlayerDigLogic()
    {
        _horizontalDirection = 0;
        _verticalDirection = 0;
        _timer = 0;
        _playerManager = PlayerManager.Instance;
    }

    public void UpdateTimer(float deltaTime)
    {
        _timer += deltaTime;
    }

    public void ChangeHorizontalDirection(float direction)
    {
        _horizontalDirection = Math.Clamp(direction, -1f, 1f);
    }

    public void ChangeVerticalDirection(float direction)
    {
        _verticalDirection = Math.Clamp(direction, -1f, 1f);
    }

    public bool BlockHit(GameObject objectHit)
    {
        if (_timer >= _playerManager.EquippedItem.Cooldown && objectHit != null && objectHit.CompareTag("Block"))
        {
            _timer = 0;
            return true;
        }
        return false;
    }
    
    public Vector2 ComputeRaycastDirection(bool IsClimbing)
    {
        if (IsClimbing)
        {
            return ComputeHorizontalRaycast();
        }
        return ComputeWalkingRaycast();
    }
    private Vector2 ComputeWalkingRaycast()
    {
        if (_verticalDirection != 0) return new Vector2(0, _verticalDirection);

        return ComputeHorizontalRaycast();
    }

    private Vector2 ComputeHorizontalRaycast()
    {
        return new Vector2(_horizontalDirection, 0);
    }
}
