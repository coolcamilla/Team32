using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator
{
    private int initX, width, height, worldDepth, reliefAmplitude;
    public int[] SurfaceY { get; private set; }
    public int[,] LayerBottoms { get; private set; }
    public GridCell[,] Grid { get; private set; }

    private HashSet<Vector2Int> _blockedDepositCells;

    public WorldGenerator(int initX, int width, int height, int worldDepth, int reliefAmplitude)
    {
        this.initX = initX;
        this.width = width;
        this.height = height;
        this.worldDepth = worldDepth;
        this.reliefAmplitude = reliefAmplitude;
    }

    public void GenerateBaseTerrain(List<LayerDefinition> layers)
    {
        int columns = width - initX;
        InitializeArrays(columns);
        GenerateSurfaceHeights(columns);
        GenerateLayerBorders(columns, layers);
        FillGrid(columns, layers);

        _blockedDepositCells = new HashSet<Vector2Int>();
    }

    private void InitializeArrays(int columns)
    {
        SurfaceY = new int[columns];
        Grid = new GridCell[columns, Mathf.Abs(worldDepth) + height + 2];
    }

    private void GenerateSurfaceHeights(int columns)
    {
        int prevSurfaceY = height - 1;
        for (int x = 0; x < columns; x++)
        {
            prevSurfaceY = Mathf.Clamp(prevSurfaceY + Random.Range(-reliefAmplitude, reliefAmplitude + 1),
                height - 1 - reliefAmplitude, height - 1 + reliefAmplitude);
            SurfaceY[x] = prevSurfaceY;
        }
    }

    private void GenerateLayerBorders(int columns, List<LayerDefinition> layers)
    {
        LayerBottoms = new int[columns, layers.Count];
        for (int i = 0; i < layers.Count; i++)
        {
            int amp = layers[i].borderReliefAmplitude;
            int baseY = layers[i].minY;
            int prevY = baseY;

            for (int x = 0; x < columns; x++)
            {
                prevY = Mathf.Clamp(prevY + Random.Range(-amp, amp + 1), baseY - amp, baseY + amp);
                LayerBottoms[x, i] = prevY;
            }
        }
    }

    private void FillGrid(int columns, List<LayerDefinition> layers)
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = SurfaceY[x]; y >= worldDepth; y--)
            {
                if (y == SurfaceY[x])
                {
                    SetCell(x, y, CellType.Grass, BackgroundType.None);
                }
                else
                {
                    LayerDefinition layer = GetLayerAt(x, y, layers);
                    if (layer != null)
                        SetCell(x, y, layer.baseBlock, layer.baseBackground);
                    else
                        SetCell(x, y, CellType.Stone, BackgroundType.Stone);
                }
            }
        }
    }

    private LayerDefinition GetLayerAt(int x, int y, List<LayerDefinition> layers)
    {
        for (int i = 0; i < layers.Count; i++)
        {
            int bottom = LayerBottoms[x, i];
            int top = layers[i].maxY;

            if (i == 0) top = SurfaceY[x];
            else if (LayerBottoms[x, i - 1] - 1 < top) top = LayerBottoms[x, i - 1] - 1;

            if (y >= bottom && y <= top) return layers[i];
        }
        return null;
    }

    public void GenerateDeposits(List<LayerDefinition> layers)
    {
        for (int i = 0; i < layers.Count; i++)
            ProcessLayerDeposits(layers[i], i, layers);
    }

    private void ProcessLayerDeposits(LayerDefinition layer, int layerIndex, List<LayerDefinition> allLayers)
    {
        foreach (var deposit in layer.deposits)
        {
            int spawned = 0;
            int attempts = 0;

            while (spawned < deposit.depositsPerLayer && attempts < 200)
            {
                attempts++;
                if (TrySpawnCluster(layer, layerIndex, deposit, allLayers))
                    spawned++;
            }
        }
    }

    private bool TrySpawnCluster(LayerDefinition layer, int layerIndex, DepositDefinition deposit, List<LayerDefinition> allLayers)
    {
        int startX = Random.Range(0, width - initX);
        Vector2Int startPos = GetRandomPositionInLayer(startX, layerIndex, allLayers);

        if (_blockedDepositCells.Contains(startPos)) return false;
        if (GetCell(startPos.x, startPos.y).foreground != layer.baseBlock) return false;

        List<Vector2Int> bgCluster = GenerateBackgroundCluster(startPos, deposit, layer, layerIndex, allLayers);
        List<Vector2Int> fgCluster = GetForegroundCluster(bgCluster, deposit);

        ApplyClusterToGrid(bgCluster, fgCluster, deposit);
        return true;
    }

    private Vector2Int GetRandomPositionInLayer(int x, int layerIndex, List<LayerDefinition> allLayers)
    {
        int bottomY = LayerBottoms[x, layerIndex];
        int topY = allLayers[layerIndex].maxY;

        if (layerIndex == 0) topY = SurfaceY[x];
        else if (layerIndex > 0 && LayerBottoms[x, layerIndex - 1] - 1 < topY) topY = LayerBottoms[x, layerIndex - 1] - 1;

        if (topY < bottomY) topY = bottomY;
        int y = Random.Range(bottomY, topY + 1);
        return new Vector2Int(x, y);
    }

    private List<Vector2Int> GenerateBackgroundCluster(Vector2Int startPos, DepositDefinition deposit, LayerDefinition layer, int layerIndex, List<LayerDefinition> allLayers)
    {
        int targetSize = Random.Range(deposit.minBackgroundSize, deposit.maxBackgroundSize + 1);
        List<Vector2Int> cluster = new List<Vector2Int> { startPos };
        int safetyCounter = 0;

        while (cluster.Count < targetSize && safetyCounter < 50)
        {
            safetyCounter++;
            Vector2Int baseCell = cluster[Random.Range(0, cluster.Count)];
            Vector2Int nextCell = GetRandomNeighbor(baseCell);

            if (IsValidClusterCell(nextCell, layer, layerIndex, cluster, allLayers))
                cluster.Add(nextCell);
        }
        return cluster;
    }

    private Vector2Int GetRandomNeighbor(Vector2Int cell)
    {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        return cell + directions[Random.Range(0, 4)];
    }

    private bool IsValidClusterCell(Vector2Int cell, LayerDefinition layer, int layerIndex, List<Vector2Int> cluster, List<LayerDefinition> allLayers)
    {
        int yIndex = cell.y - worldDepth;
        if (cell.x < 0 || cell.x >= width - initX || yIndex < 0 || yIndex >= Grid.GetLength(1))
            return false;

        int bottomY = LayerBottoms[cell.x, layerIndex];
        int topY = layer.maxY;

        if (layerIndex == 0) topY = SurfaceY[cell.x];
        else if (layerIndex > 0 && LayerBottoms[cell.x, layerIndex - 1] - 1 < topY) topY = LayerBottoms[cell.x, layerIndex - 1] - 1;

        if (cell.y < bottomY || cell.y > topY) return false;
        if (cluster.Contains(cell)) return false;

        if (_blockedDepositCells.Contains(cell)) return false;

        return GetCell(cell.x, cell.y).foreground == layer.baseBlock;
    }

    private List<Vector2Int> GetForegroundCluster(List<Vector2Int> bgCluster, DepositDefinition deposit)
    {
        int targetSize = Mathf.Min(Random.Range(deposit.minForegroundSize, deposit.maxForegroundSize + 1), bgCluster.Count);
        List<Vector2Int> fgCluster = new List<Vector2Int>();

        for (int i = 0; i < bgCluster.Count; i++)
        {
            int randIdx = Random.Range(i, bgCluster.Count);
            (bgCluster[i], bgCluster[randIdx]) = (bgCluster[randIdx], bgCluster[i]);
        }

        for (int i = 0; i < targetSize; i++)
            fgCluster.Add(bgCluster[i]);

        return fgCluster;
    }

    private void ApplyClusterToGrid(List<Vector2Int> bgCluster, List<Vector2Int> fgCluster, DepositDefinition deposit)
    {
        Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, Vector2Int.zero };

        foreach (var pos in bgCluster)
        {
            GridCell cell = GetCell(pos.x, pos.y);
            cell.background = deposit.bgType;
            SetCell(pos.x, pos.y, cell.foreground, cell.background);

            foreach (var dir in directions)
            {
                _blockedDepositCells.Add(pos + dir);
            }    
        }

        foreach (var pos in fgCluster)
        {
            GridCell cell = GetCell(pos.x, pos.y);
            cell.foreground = deposit.oreType;
            SetCell(pos.x, pos.y, cell.foreground, cell.background);
        }
    }

    public int GetLayerBottom(int x, int layerIndex)
    {
        if (x < 0 || x >= LayerBottoms.GetLength(0) || layerIndex >= LayerBottoms.GetLength(1)) return worldDepth;
        return LayerBottoms[x, layerIndex];
    }

    private int GetYIndex(int worldY)
    {
        return worldY - worldDepth;
    }
    private GridCell GetCell(int x, int y)
    {
        return Grid[x, GetYIndex(y)];
    }
    private void SetCell(int x, int y, CellType fg, BackgroundType bg)
    {
        Grid[x, GetYIndex(y)] = new GridCell { foreground = fg, background = bg };
    }
}