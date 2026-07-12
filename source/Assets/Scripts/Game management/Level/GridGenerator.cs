using UnityEngine;
using System.Collections.Generic;
using System;

public class GridGenerator : MonoBehaviour
{
    public static GridGenerator Instance { get; private set; }

    [Header("Terrain Settings")]
    public int initX = 0;
    public int width = 20;
    public int height = 5;
    public int worldDepth = -10;
    public int reliefAmplitude = 1; 

    [Header("Layers")]
    [SerializeField] private List<LayerDefinition> layers;

    [Header("Block Prefabs (Foreground)")]
    [SerializeField] private GameObject dirtWithGrassPrefab;
    [SerializeField] private List<BlockPrefabMapping> blockPrefabs;

    [Header("Background Prefabs")]
    [SerializeField] private List<BackgroundPrefabMapping> bgPrefabs;

    [Header("Data")]
    public BlockTypeData dirtGrassBlockData;

    [Header("Station System")]
    [SerializeField] private GameObject depositNodePrefab;

    private WorldGenerator _worldGenerator;
    private float _cellSize = 2.5f;
    private Dictionary<CellType, GameObject> _blockPrefabDict;
    private Dictionary<BackgroundType, GameObject> _bgPrefabDict;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        _blockPrefabDict = new Dictionary<CellType, GameObject>();
        foreach (var mapping in blockPrefabs)
            if (!_blockPrefabDict.ContainsKey(mapping.type))
                _blockPrefabDict.Add(mapping.type, mapping.prefab);

        _bgPrefabDict = new Dictionary<BackgroundType, GameObject>();
        foreach (var mapping in bgPrefabs)
            if (!_bgPrefabDict.ContainsKey(mapping.type))
                _bgPrefabDict.Add(mapping.type, mapping.prefab);
    }

    private void Start() => GenerateWorld();

    public void GenerateWorld()
    {
        _worldGenerator = new WorldGenerator(initX, width, height, worldDepth, reliefAmplitude);
        _worldGenerator.GenerateBaseTerrain(layers);
        _worldGenerator.GenerateDeposits(layers);

        foreach (Transform t in transform) Destroy(t.gameObject);
        SpawnDepositNodes();
        RenderWorld();
    }

    private void RenderWorld()
    {
        int columns = width - initX;
        Sprite[] grassSprites = dirtGrassBlockData.possibleSprites;

        for (int x = 0; x < columns; x++)
        {
            for (int y = worldDepth; y <= _worldGenerator.SurfaceY[x]; y++)
            {
                GridCell cell = _worldGenerator.Grid[x, y - worldDepth];
                Vector3 pos = new Vector3((initX + x) * _cellSize, y * _cellSize, 0);

                SpawnBackground(cell.background, pos);
                SpawnForeground(cell.foreground, pos, x, y, grassSprites, columns);
            }
        }
    }

    private void SpawnDepositNodes()
    {
        if (depositNodePrefab == null) return;

        foreach (var data in _worldGenerator.GeneratedDeposits)
        {
            float worldX = (initX + data.startCell.x + 0.5f) * _cellSize;
            float worldY = (data.startCell.y + 0.5f) * _cellSize;
            Vector3 spawnPos = new Vector3(worldX, worldY, 0);

            GameObject nodeObj = Instantiate(depositNodePrefab, spawnPos, Quaternion.identity, transform);
            DepositNode node = nodeObj.GetComponent<DepositNode>();

            if (node != null && data.depositDefinition.stationRecipe != null)
            {
                node.Initialize(data.depositDefinition.stationRecipe);
            }
        }
    }

    private void SpawnBackground(BackgroundType bgType, Vector3 pos)
    {
        if (bgType == BackgroundType.None) return;
        if (_bgPrefabDict.TryGetValue(bgType, out GameObject prefab) && prefab != null)
        {
            Instantiate(prefab, new Vector3(pos.x, pos.y, 2), Quaternion.identity, transform);
        }
    }

    private void SpawnForeground(CellType fgType, Vector3 pos, int x, int y, Sprite[] grassSprites, int columns)
    {
        if (fgType == CellType.Empty) return;

        GameObject prefab = fgType == CellType.Grass ? dirtWithGrassPrefab : null;
        if (fgType != CellType.Grass) _blockPrefabDict.TryGetValue(fgType, out prefab);

        if (prefab != null)
        {
            GameObject blockObj = Instantiate(prefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity, transform);
            if (fgType == CellType.Grass) SetupGrassSprite(blockObj, x, y, grassSprites, columns);
        }
    }

    private void SetupGrassSprite(GameObject blockObj, int x, int y, Sprite[] grassSprites, int columns)
    {
        BlockBehaviour block = blockObj.GetComponent<BlockBehaviour>();
        if (block != null && grassSprites != null && grassSprites.Length >= 3)
        {
            int currentBottom = _worldGenerator.GetLayerBottom(x, 0);
            int leftBottom = (x > 0) ? _worldGenerator.GetLayerBottom(x - 1, 0) : currentBottom;
            int rightBottom = (x < columns - 1) ? _worldGenerator.GetLayerBottom(x + 1, 0) : currentBottom;

            bool hasLeft = (x > 0) && (y >= leftBottom && y <= _worldGenerator.SurfaceY[x - 1]);
            bool hasRight = (x < columns - 1) && (y >= rightBottom && y <= _worldGenerator.SurfaceY[x + 1]);

            Sprite chosen = (!hasLeft && hasRight) ? grassSprites[0] : (hasLeft && !hasRight) ? grassSprites[2] : grassSprites[1];
            block.SetSprite(chosen);
        }
    }

    public int GetSurfaceHeight(int x) => (x >= 0 && x < _worldGenerator.SurfaceY.Length) ? _worldGenerator.SurfaceY[x] : 0;
}

[Serializable] public class BlockPrefabMapping { public CellType type; public GameObject prefab; }
[Serializable] public class BackgroundPrefabMapping { public BackgroundType type; public GameObject prefab; }