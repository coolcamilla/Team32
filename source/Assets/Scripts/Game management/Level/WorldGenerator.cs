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
                int minClamp = Mathf.Max(worldDepth, baseY - amp);
                prevY = Mathf.Clamp(prevY + Random.Range(-amp, amp + 1), minClamp, baseY + amp);
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
        int columns = width - initX;
        if (columns < 2) return false;

        int startX = Random.Range(0, columns - 1);
        Vector2Int startPos = GetRandomPositionInLayer(startX, layerIndex, allLayers);

        Vector2Int c1 = startPos;
        Vector2Int c2 = new Vector2Int(startPos.x + 1, startPos.y);
        Vector2Int c3 = new Vector2Int(startPos.x, startPos.y + 1);
        Vector2Int c4 = new Vector2Int(startPos.x + 1, startPos.y + 1);

        if (!IsCellValidForDeposit(c1, layer, layerIndex) ||
            !IsCellValidForDeposit(c2, layer, layerIndex) ||
            !IsCellValidForDeposit(c3, layer, layerIndex) ||
            !IsCellValidForDeposit(c4, layer, layerIndex))
        {
            return false;
        }

        List<Vector2Int> bgCluster = new List<Vector2Int> { c1, c2, c3, c4 };
        List<Vector2Int> fgCluster = new List<Vector2Int>();

        int pairChoice = Random.Range(0, 4);
        switch (pairChoice)
        {
            case 0: fgCluster.Add(c1); fgCluster.Add(c2); break;
            case 1: fgCluster.Add(c3); fgCluster.Add(c4); break;
            case 2: fgCluster.Add(c1); fgCluster.Add(c3); break;
            case 3: fgCluster.Add(c2); fgCluster.Add(c4); break;
        }

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
        int y = Random.Range(bottomY, topY);
        return new Vector2Int(x, y);
    }

    private bool IsCellValidForDeposit(Vector2Int cell, LayerDefinition layer, int layerIndex)
    {
        int yIndex = cell.y - worldDepth;
        if (cell.x < 0 || cell.x >= width - initX || yIndex < 0 || yIndex >= Grid.GetLength(1))
            return false;

        int bottomY = LayerBottoms[cell.x, layerIndex];
        int topY = layer.maxY;

        if (layerIndex == 0) topY = SurfaceY[cell.x];
        else if (layerIndex > 0 && LayerBottoms[cell.x, layerIndex - 1] - 1 < topY) topY = LayerBottoms[cell.x, layerIndex - 1] - 1;

        if (cell.y < bottomY || cell.y > topY) return false;
        if (_blockedDepositCells.Contains(cell)) return false;

        return GetCell(cell.x, cell.y).foreground == layer.baseBlock;
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