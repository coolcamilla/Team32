using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class DrillBehaviour : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Animator _backgroundAnimator;
    [SerializeField] private Animator _drillAnimator;
    [SerializeField] private Transform _signPosition;
    [SerializeField] private TextMeshProUGUI _fuelCounter;
    [SerializeField] private TextMeshProUGUI _depthCounter;
    [SerializeField] private TextMeshProUGUI _powerStatistics;
    [SerializeField] private TextMeshProUGUI _speedStatistics;

    [Header("Panels")]
    [SerializeField] private GameObject _engineCraftPanel;
    [SerializeField] private GameObject _drillCraftPanel;
    [SerializeField] private GameObject _fuelTankCraftPanel;

    [Header("Level 1 drill modules")]
    [SerializeField] private Engine _newEngine;
    [SerializeField] private Drill _newDrill;
    [SerializeField] private FuelTank _newFuelTank;

    [SerializeField] private float _dropForceMultiplier = 10.0f;

    private InventoryManager _inventoryManager;
    private DrillLogic _logic;
    private List<DropChance> _chances;
    private System.Random _rand;

    private event UnityAction OnSecondPassed;
    
    private void Awake()
    {
        _logic = new DrillLogic();
        _fuelCounter.SetText($"Fuel: 0/{_logic.CurrentFuelTank.Capacity}");
        _depthCounter.SetText("Depth: 0.00 m");

        _inventoryManager = GetComponent<InventoryManager>();
        
        _rand = new System.Random();

        _chances = new();

        _chances.Add(new DropChance(ItemType.Clay, 0.1f));
        _chances.Add(new DropChance(ItemType.Pebbles, 0.15f));
        _chances.Add(new DropChance(ItemType.Stick, 0.35f));
        _chances.Add(new DropChance(ItemType.Seedling, 0.7f));

        SyncStatistics();
    }

    private void Update()
    {
        _logic.Tick(Time.deltaTime);
        TryProcessSecond();
    }

    private void OnEnable()
    {
        OnSecondPassed += SyncDepth;
        OnSecondPassed += SyncFuel;
        OnSecondPassed += TryDrop;
        OnSecondPassed += SyncVisuals;
        OnSecondPassed += SyncStatistics;
    }

    private void OnDisable()
    {
        OnSecondPassed -= SyncDepth;
        OnSecondPassed -= SyncFuel;
        OnSecondPassed -= TryDrop;
        OnSecondPassed -= SyncVisuals;
        OnSecondPassed -= SyncStatistics;
    }

    public void SyncDepth()
    {
        _depthCounter.SetText($"Depth: {_logic.Depth:F2} m");
    }

    private void SyncFuel()
    {
        _fuelCounter.SetText($"Fuel: {_logic.FuelCount}/{_logic.CurrentFuelTank.Capacity}");
    }

    private void SyncVisuals()
    {
        if (_logic.Energy >= _logic.Power || _logic.FuelCount > 0)
        {
            _drillAnimator.SetBool("IsGotEnergy", true);
            _backgroundAnimator.SetBool("IsMoving", true);
            _particleSystem.Play(true);
        }
        else
        {
            _drillAnimator.SetBool("IsGotEnergy", false);
            _backgroundAnimator.SetBool("IsMoving", false);
            _particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void SyncStatistics()
    {
        _powerStatistics.SetText($"{_logic.Power} W");
        _speedStatistics.SetText($"{_logic.Speed * 60} m/min");
    }

    public void TryAddFuel(Fuel fuel)
    {
        if (!_inventoryManager.IsEnough(TypeToItemData.Convert(fuel.Type)))
        {
            return;
        }
        if (_logic.TryAddFuel(fuel)) 
        {
            _inventoryManager.Spend(TypeToItemData.Convert(fuel.Type));
            SyncFuel();
        }
    }

    private void TryProcessSecond()
    {
        if (_logic.TryProcessSecond())
        {
            OnSecondPassed?.Invoke();
        }
    }

    private void TryDrop()
    {
        if (_logic.IsMarkPassed())
        {
            Drop();
        }
    }

    private void Drop()
    {
        foreach(var dropChance in _chances)
        {
            float randomNumber = _rand.Next(0, 100) / 100f;
            if (randomNumber < dropChance.Chance)
            {
                GameObject newGO = Instantiate(TypeToPrefab.Convert(dropChance.GetMaterial), _signPosition);
                newGO.GetComponent<Rigidbody2D>().AddForce(new Vector2(_rand.Next(-1, 2), 1) * _dropForceMultiplier);
            }
        }
    }

    public void TryUpgradeEngine()
    {
        if (_inventoryManager.IsEnough(TypeToItemData.Convert(ItemType.Pebbles), 10) &&
            _inventoryManager.IsEnough(TypeToItemData.Convert(ItemType.Clay), 3))
        {
            _inventoryManager.Spend(TypeToItemData.Convert(ItemType.Pebbles), 10);
            _inventoryManager.Spend(TypeToItemData.Convert(ItemType.Clay), 3);

            _logic.CurrentEngine = _newEngine;

            Destroy(_engineCraftPanel);
        }
    }

    public void TryUpgradeDrill()
    {
        if (_inventoryManager.IsEnough(TypeToItemData.Convert(ItemType.Pebbles), 5) &&
            _inventoryManager.IsEnough(TypeToItemData.Convert(ItemType.Stick), 5))
        {
            _inventoryManager.Spend(TypeToItemData.Convert(ItemType.Pebbles), 5);
            _inventoryManager.Spend(TypeToItemData.Convert(ItemType.Stick), 5);

            _logic.CurrentDrill = _newDrill;

            Destroy(_drillCraftPanel);
        }
    }

    public void TryUpgradeFuelTank()
    {
        if (_inventoryManager.IsEnough(TypeToItemData.Convert(ItemType.Pebbles), 10))
        {
            _inventoryManager.Spend(TypeToItemData.Convert(ItemType.Pebbles), 10);

            _logic.CurrentFuelTank = _newFuelTank;

            Destroy(_fuelTankCraftPanel);
        }
    }
}
