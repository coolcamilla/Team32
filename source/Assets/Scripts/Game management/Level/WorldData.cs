using UnityEngine;
using System.Collections.Generic;

public enum CellType
{
    Empty,
    Grass,
    Dirt,
    Stone,
    Clay,
    Coal,
    Copper,
    Flint
}

public enum BackgroundType
{
    None,
    Dirt,
    Stone,
    Clay,
    Coal,
    Copper,
    Flint
}

public struct GridCell
{
    public CellType foreground;
    public BackgroundType background;
}



