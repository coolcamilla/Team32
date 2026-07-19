using TMPro;
using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DrillBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _demoEndButton;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Animator _backgroundAnimator;
    [SerializeField] private Animator _drillAnimator;
    [SerializeField] private Transform _signPosition;
    [SerializeField] private TextMeshProUGUI _depthCounter;
    [SerializeField] private TextMeshProUGUI _powerStatistics;
    [SerializeField] private TextMeshProUGUI _speedStatistics;
    [SerializeField] private Slider _fuelSlider;
    [SerializeField] private List<DrillLayer> _dropMapsQueueFields;
    [SerializeField] private List<Engine> _enginesQueueFields;
    [SerializeField] private List<Bit> _bitsQueueFields;
    [SerializeField] private List<FuelTank> _fuelTanksQueueFields;

    [SerializeField] private Tilemap _fgBlocks;
    [SerializeField] private Tilemap _bgBlocks;

    [Header("Panels")]
    [SerializeField] private UpgradePanel _engineUpgradePanel;
    [SerializeField] private UpgradePanel _bitUpgradePanel;
    [SerializeField] private UpgradePanel _fuelTankUpgradePanel;

    [SerializeField] private float _dropForceMultiplier = 10.0f;
    [SerializeField] private AudioSource _audioSource;

    private Queue<DrillLayer> _drillLayersQueue;
    private Queue<Engine> _enginesQueue;
    private Queue<Bit> _bitsQueue;
    private Queue<FuelTank> _fuelTanksQueue;

    private InventoryManager _inventoryManager;
    private DrillLogic _logic;
    private DrillLayer _currentLayer;
    private System.Random _rand;
    private MultipleSoundsSourceBehaviour _multipleAudioSource;

    private event UnityAction OnSecondPassed;
    private event UnityAction OnLayerUpdate;
    
    private void Awake()
    {
        _multipleAudioSource = GameObject.FindGameObjectWithTag("Global Audio").GetComponent<MultipleSoundsSourceBehaviour>();


        CreateQueues();
        UpdateCurrentLayer();

        _logic = new DrillLogic(_currentLayer)
        {
            NextLayer = _drillLayersQueue.Peek()
        };

        _depthCounter.SetText("0.00");
        _fuelSlider.maxValue = _logic.CurrentFuelTank.Capacity;

        _inventoryManager = GetComponent<InventoryManager>();
        
        _rand = new System.Random();

        SyncStatistics();
        RefreshPanels();
    }

    private void Update()
    {
        _logic.Tick(Time.deltaTime);
        TryProcessSecond();
        TryUpdateLayer();
        if (_logic.Depth >= 7) _demoEndButton.SetActive(true);

        if ((_logic.Energy >= _logic.Power || _logic.FuelCount > 0) && !_logic.IsStuck()) TryRunAudio();
        else StopAudio();
    }

    private void OnEnable()
    {
        OnSecondPassed += SyncDepth;
        OnSecondPassed += TryDrop;
        OnSecondPassed += SyncAnimations;
        OnSecondPassed += SyncStatistics;
        OnSecondPassed += SyncFuel;

        OnLayerUpdate += UpdateSprites;
        OnLayerUpdate += UpdateParticles;
    }

    private void OnDisable()
    {
        OnSecondPassed -= SyncDepth;
        OnSecondPassed -= TryDrop;
        OnSecondPassed -= SyncAnimations;
        OnSecondPassed -= SyncStatistics;
        OnSecondPassed -= SyncFuel;

        OnLayerUpdate -= UpdateSprites;
        OnLayerUpdate -= UpdateParticles;
    }

    private void CreateQueues()
    {
        _drillLayersQueue = new();
        _enginesQueue = new();
        _bitsQueue = new();
        _fuelTanksQueue = new();

        foreach(DrillLayer map in _dropMapsQueueFields)
        {
            _drillLayersQueue.Enqueue(map);
        }

        foreach (Engine engine in _enginesQueueFields)
        {
            _enginesQueue.Enqueue(engine);
        }

        foreach (Bit bit in _bitsQueueFields)
        {
            _bitsQueue.Enqueue(bit);
        }

        foreach (FuelTank tank in _fuelTanksQueueFields)
        {
            _fuelTanksQueue.Enqueue(tank);
        }
    }

    private void UpdateCurrentLayer()
    {
        if (_drillLayersQueue.Count > 0)
            _currentLayer = _drillLayersQueue.Dequeue();
    }

    public void SyncDepth()
    {
        _depthCounter.SetText(FormattableString.Invariant($"{_logic.Depth:F2}"));
    }

    private void SyncFuel()
    {
        _fuelSlider.value = _logic.FuelCount;
    }

    private void SyncAnimations()
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
        _powerStatistics.SetText(FormattableString.Invariant($"{_logic.Power}"));
        _speedStatistics.SetText(FormattableString.Invariant($"{_logic.Speed * 60:F2}"));
        _fuelSlider.maxValue = _logic.CurrentFuelTank.Capacity;
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
            SyncAnimations();
            SyncStatistics();
            SyncFuel();
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

    public int EngineTier => _enginesQueueFields.Count - _enginesQueue.Count;
    public int BitTier => _bitsQueueFields.Count - _bitsQueue.Count;
    public int FuelTankTier => _fuelTanksQueueFields.Count - _fuelTanksQueue.Count;
    public int LayerTier => _dropMapsQueueFields.Count - _drillLayersQueue.Count;
    public float Depth => _logic.Depth;

    public void LoadProgress(int engineTier, int bitTier, int fuelTankTier, int layerTier, float depth)
    {
        while (EngineTier < engineTier && _enginesQueue.Count > 0)
        {
            _logic.CurrentEngine = _enginesQueue.Dequeue();
        }

        while (BitTier < bitTier && _bitsQueue.Count > 0)
        {
            _logic.CurrentBit = _bitsQueue.Dequeue();
        }

        while (FuelTankTier < fuelTankTier && _fuelTanksQueue.Count > 0)
        {
            _logic.CurrentFuelTank = _fuelTanksQueue.Dequeue();
        }

        while (LayerTier < layerTier && _drillLayersQueue.Count > 0)
        {
            UpdateCurrentLayer();
        }
        _logic.Layer = _currentLayer;
        if (_drillLayersQueue.Count > 0) _logic.NextLayer = _drillLayersQueue.Peek();

        _logic.SetDepth(depth);

        RefreshPanelsSafe();
        SyncStatistics();
        SyncDepth();
        SyncFuel();
        UpdateSprites();
        UpdateParticles();
    }

    private void RefreshPanelsSafe()
    {
        _bitUpgradePanel.Refresh(_bitsQueue.Count > 0 ? _bitsQueue.Peek().Recipe : null);
        _engineUpgradePanel.Refresh(_enginesQueue.Count > 0 ? _enginesQueue.Peek().Recipe : null);
        _fuelTankUpgradePanel.Refresh(_fuelTanksQueue.Count > 0 ? _fuelTanksQueue.Peek().Recipe : null);
    }

    private bool TryUpdateLayer()
    {
        if (!_logic.IsLayerPossibleToUpdated() || _drillLayersQueue.Count == 0) return false;

        UpdateLayer();
        return true;
    }

    private void UpdateLayer()
    {
        UpdateCurrentLayer();
        _logic.Layer = _currentLayer;
        if (_drillLayersQueue.Count > 0)
            _logic.NextLayer = _drillLayersQueue.Peek();

        OnLayerUpdate?.Invoke();
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
        Engine newEngine = _enginesQueue.Peek();
        if (!IsEnoughResourcesForUpgrade(newEngine.Recipe)) return;
        SpendResourcesForRecipe(newEngine.Recipe);

        _logic.CurrentEngine = newEngine;
        _enginesQueue.Dequeue();

        try
        {
            _engineUpgradePanel.Refresh(_enginesQueue.Peek().Recipe);
        } catch {
            _engineUpgradePanel.Refresh(null);
        }

        _multipleAudioSource.PlayCraftSound();
    }

    public void TryUpgradeDrill()
    {
        Bit newBit = _bitsQueue.Peek();
        if (!IsEnoughResourcesForUpgrade(newBit.Recipe)) return;
        SpendResourcesForRecipe(newBit.Recipe);

        _logic.CurrentBit = newBit;
        _bitsQueue.Dequeue();

        try
        {
            _bitUpgradePanel.Refresh(_bitsQueue.Peek().Recipe);
        }
        catch
        {
            _bitUpgradePanel.Refresh(null);
        }

        _multipleAudioSource.PlayCraftSound();
    }

    public void TryUpgradeFuelTank()
    {
        FuelTank newFuelTank = _fuelTanksQueue.Peek();
        if (!IsEnoughResourcesForUpgrade(newFuelTank.Recipe)) return;
        SpendResourcesForRecipe(newFuelTank.Recipe);

        _logic.CurrentFuelTank = newFuelTank;
        _fuelTanksQueue.Dequeue();

        try
        {
            _fuelTankUpgradePanel.Refresh(_fuelTanksQueue.Peek().Recipe);
        }
        catch
        {
            _fuelTankUpgradePanel.Refresh(null);
        }

        _multipleAudioSource.PlayCraftSound();
    }

    private bool IsEnoughResourcesForUpgrade(CraftRecipe recipe)
    {
        foreach(var entry in recipe.Materials)
        {
            if (!_inventoryManager.IsEnough(TypeToItemData.Convert(entry.Type), entry.Quantity)) return false;
        }
        return true;
    }

    private void SpendResourcesForRecipe(CraftRecipe recipe)
    {
        foreach (var entry in recipe.Materials)
        {
            _inventoryManager.Spend(TypeToItemData.Convert(entry.Type), entry.Quantity);
        }
    }

    private void RefreshPanels()
    {
        _bitUpgradePanel.Refresh(_bitsQueue.Peek().Recipe);
        _engineUpgradePanel.Refresh(_enginesQueue.Peek().Recipe);
        _fuelTankUpgradePanel.Refresh(_fuelTanksQueue.Peek().Recipe);
    }

    private void TryRunAudio()
    {
        if (_audioSource.isPlaying || !_audioSource.gameObject.activeSelf) return;
        else _audioSource.Play();
    }

    private void StopAudio()
    {
        _audioSource.Stop();
    }
}
