using System;
using UnityEngine;

[Serializable] public enum ItemType
{
    None = 0,
    Test = 1,

    // INSTRUMENTS
    // Hotbar constraints:
    // 100 to 139 - primary
    // 140 to 179 - secondary
    // 180 - 219 - 3rd slot
    // 220 - 259 - 4th slot
    // 260 - 299 - 5th slot
    WoodenShovel = 100,
    StoneShovel = 101,
    StonePickaxe = 102,
    FlintPickaxe = 103,
    CopperPickaxe = 104,
    
    WoodenDrill = 140,

    //RESOURCES
    //from 300 and so on
    Stick = 300,
    Pebbles = 301,
    Rock = 302,
    Clay = 303,
    Seedling = 304,
    Copper = 305,
    Flint = 306,
    Coal = 307
}
