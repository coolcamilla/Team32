using System.Collections.Generic;
using UnityEngine;

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
