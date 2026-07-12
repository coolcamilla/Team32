using TMPro;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

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
    [SerializeField] private List<DrillLayer> _dropMapsQueueFields;
    [SerializeField] private Tilemap _fgBlocks;
    [SerializeField] private Tilemap _bgBlocks;

    [Header("Panels")]
    [SerializeField] private GameObject _engineCraftPanel;
    [SerializeField] private GameObject _drillCraftPanel;
    [SerializeField] private GameObject _fuelTankCraftPanel;

    [Header("Level 1 drill modules")]
    [SerializeField] private Engine _newEngine;
    [SerializeField] private Drill _newDrill;
    [SerializeField] private FuelTank _newFuelTank;

    [SerializeField] private float _dropForceMultiplier = 10.0f;

    private Queue<DrillLayer> _dropMapQueue;
    private InventoryManager _inventoryManager;
    private DrillLogic _logic;
    private DrillLayer _currentLayer;
    private System.Random _rand;

    private event UnityAction OnSecondPassed;
    private event UnityAction OnLayerUpdate;
    
    private void Awake()
    {
        _logic = new DrillLogic();
        _fuelCounter.SetText($"Fuel: 0/{_logic.CurrentFuelTank.Capacity}");
        _depthCounter.SetText("Depth: 0.00 m");

        _inventoryManager = GetComponent<InventoryManager>();
        
        _rand = new System.Random();

        CreateQueue();
        UpdateCurrentLayer();
        SyncStatistics();
    }

    private void Update()
    {
        _logic.Tick(Time.deltaTime);
        TryProcessSecond();
        TryUpdateLayer();
    }

    private void OnEnable()
    {
        OnSecondPassed += SyncDepth;
        OnSecondPassed += SyncFuel;
        OnSecondPassed += TryDrop;
        OnSecondPassed += SyncVisuals;
        OnSecondPassed += SyncStatistics;

        OnLayerUpdate += UpdateSprites;
        OnLayerUpdate += UpdateParticles;
        OnLayerUpdate += UpdateModifier;
    }

    private void OnDisable()
    {
        OnSecondPassed -= SyncDepth;
        OnSecondPassed -= SyncFuel;
        OnSecondPassed -= TryDrop;
        OnSecondPassed -= SyncVisuals;
        OnSecondPassed -= SyncStatistics;

        OnLayerUpdate -= UpdateSprites;
        OnLayerUpdate -= UpdateParticles;
        OnLayerUpdate -= UpdateModifier;
    }

    private void CreateQueue()
    {
        _dropMapQueue = new();
        foreach(DrillLayer map in _dropMapsQueueFields)
        {
            _dropMapQueue.Enqueue(map);
        }
    }

    private void UpdateCurrentLayer()
    {
        if (_dropMapQueue.Count > 0)
            _currentLayer = _dropMapQueue.Dequeue();
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
        if (!_logic.IsStuck() && (_logic.Energy >= _logic.Power || _logic.FuelCount > 0))
        {
            _drillAnimator.SetBool("IsGotEnergy", true);
            _backgroundAnimator.SetBool("IsMoving", true);
            if (!_particleSystem.isPlaying)_particleSystem.Play(true);
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
        _speedStatistics.SetText($"{_logic.Speed * 60:F2} m/min");
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
        } else
        {
            SyncVisuals();
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
        foreach(var dropChance in _currentLayer.DropChances)
        {
            float randomNumber = _rand.Next(0, 100) / 100f;
            if (randomNumber < dropChance.Chance)
            {
                GameObject newGO = Instantiate(TypeToPrefab.Convert(dropChance.GetMaterial), _signPosition);
                newGO.GetComponent<Rigidbody2D>().AddForce(new Vector2(_rand.Next(-1, 2), 1) * _dropForceMultiplier);
            }
        }
    }

    private bool TryUpdateLayer()
    {
        if (!_logic.IsLayeNeedToBeUpdated()) return false;

        UpdateLayer();
        return true;
    }

    private void UpdateLayer()
    {
        UpdateCurrentLayer();
        _logic.MarkDistance = _currentLayer.DropFrequencyInMeters;
        _logic.NewLayerDepth = 10000f;

        OnLayerUpdate?.Invoke();
    }

    private void UpdateModifier()
    {
        _logic.LayerDurability = _currentLayer.DurabilityModifier;
    }

    private void UpdateSprites()
    {
        _bgBlocks.SwapTile(GetFirstActiveTile(_bgBlocks), _currentLayer.BackgroundTile);
        _fgBlocks.SwapTile(GetFirstActiveTile(_fgBlocks), _currentLayer.ForegroundTile);
    }

    private TileBase GetFirstActiveTile(Tilemap tilemap)
    {
        BoundsInt bounds = tilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile != null)
            {
                return tile;
            }
        }
        return null; 
    }

    private void UpdateParticles()
    {
        var mainSystem = _particleSystem.main;
        mainSystem.startColor = Color.gray;
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
