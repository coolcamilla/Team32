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



