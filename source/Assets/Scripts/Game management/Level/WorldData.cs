using UnityEngine;
using System.Collections.Generic;

public enum CellType
{
    Empty,
    Grass,
    Dirt,
    Stone,
    Clay,
    Coal
}

public enum BackgroundType
{
    None,
    Dirt,
    Stone,
    Clay,
    Coal
}

public struct GridCell
{
    public CellType foreground;
    public BackgroundType background;
}

[CreateAssetMenu(fileName = "NewDeposit", menuName = "MoleDigger/Deposit Definition")]
public class DepositDefinition : ScriptableObject
{
    [Header("Ore Settings")]
    public CellType oreType;
    public BackgroundType bgType;

    [Header("Cluster Sizes")]
    public int minForegroundSize = 2;
    public int maxForegroundSize = 4;
    public int minBackgroundSize = 4;
    public int maxBackgroundSize = 7;

    [Header("Generation Count")]
    public int depositsPerLayer = 3;
}

[CreateAssetMenu(fileName = "NewLayer", menuName = "MoleDigger/Layer Definition")]
public class LayerDefinition : ScriptableObject
{
    [Header("Layer Bounds")]
    public int minY;
    public int maxY;
    public int borderReliefAmplitude = 1;

    [Header("Base Blocks")]
    public CellType baseBlock;
    public BackgroundType baseBackground;

    [Header("Deposits")]
    public List<DepositDefinition> deposits;
}