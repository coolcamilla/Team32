using UnityEngine;

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