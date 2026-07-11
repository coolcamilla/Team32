using System.Collections.Generic;
using System.Diagnostics;

public class DrillLogic
{

    private Drill _currentDrill;
    private FuelTank _currentFuelTank;
    private Engine _currentEngine;

    private Queue<Fuel> _fuelQueue;
    private float _timer;
    private float _speed;
    private float _power;
    private float _availableEnergy;
    private float _depth;
    private float _layerDurability;
    private int _previousDepthMultiplier;

    public float MarkDistance;
    public float NewLayerDepth = 3.5f;

    #region Properties
    public Drill CurrentDrill { 
        get => _currentDrill; 
        set 
        { 
            _currentDrill = value;  
            UpdateSpeed(); 
        } 
    }
    public FuelTank CurrentFuelTank { 
        get => _currentFuelTank;
        set { 
            _currentFuelTank = value;
        }
    }
    public Engine CurrentEngine
    {
        get => _currentEngine;
        set
        {
            _currentEngine = value;
            UpdateSpeed();
            UpdatePower();
        }
    }
    public float LayerDurability
    {
        get => _layerDurability;
        set
        {
            _layerDurability = value;
            UpdateSpeed();
        }
    }

    public float Depth => _depth;

    public int FuelCount => _fuelQueue.Count;

    public float Speed => _speed;
    public float Power => _power;

    public float Energy => _availableEnergy;

    #endregion
    public DrillLogic()
    {
        _fuelQueue = new();

        _currentDrill = Drill.CreateInstance<Drill>();
        _currentDrill.SetBasic();
        _currentFuelTank = FuelTank.CreateInstance<FuelTank>();
        _currentFuelTank.SetBasic();
        _currentEngine = Engine.CreateInstance<Engine>();
        _currentEngine.SetBasic();

        _availableEnergy = 0f;
        _depth = 0f;
        MarkDistance = 0.1f;
        LayerDurability = 1f;

        UpdateSpeed();
        UpdatePower();

        _previousDepthMultiplier = 0;

        _timer = 0f;

    }

    public void Tick(float time)
    {
        if (IsStuck()) return;
        _timer += time;
    }

    public bool TryAddFuel(Fuel fuel)
    {
        if (_fuelQueue.Count < CurrentFuelTank.Capacity) 
        {
            _fuelQueue.Enqueue(fuel);
            return true;
        }
        return false;
    }

    private void UpdateSpeed()
    {
        _speed = _currentDrill.Speed + _currentEngine.Speed;
        _speed /= LayerDurability;
        _speed /= 60f;
    }

    private void UpdatePower()
    {
        _power = _currentEngine.Power;
    }

    public bool TryProcessSecond()
    {
        if (_timer >= 1f && !IsStuck())
        {
            _timer -= 1f;
            return ProcessSecond();
        }
        return false;
    }

    private bool ProcessSecond()
    {
        PrepareEnergy();
        if (_availableEnergy < _power) return false;

        _availableEnergy -= _power;

        _depth += _speed;

        return true;
    }

    private void PrepareEnergy()
    {
        while (_availableEnergy < _power && _fuelQueue.Count > 0)
        {
            BurnFuel();
        }
    }

    private void BurnFuel()
    {
        _availableEnergy += _fuelQueue.Dequeue().Energy;
    }

    public bool IsMarkPassed()
    {
        if ((int)(_depth / MarkDistance) > _previousDepthMultiplier)
        {
            _previousDepthMultiplier = (int) (_depth / MarkDistance);
            return true;
        }
        return false;
    }

    public bool IsLayeNeedToBeUpdated()
    {
        return (Depth > NewLayerDepth && !IsStuck());
    }

    public bool IsStuck()
    {
        return _depth >= NewLayerDepth && 
            (_currentDrill.Name == "Basic Drill" || 
             _currentEngine.Name == "Basic Engine" ||
             _currentFuelTank.Name == "Basic Fuel Tank");
    }
}
