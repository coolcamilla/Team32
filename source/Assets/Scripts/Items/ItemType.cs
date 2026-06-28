using System;
using UnityEngine;

[Serializable] public enum ItemType
{
    None = 0,
    Test = 1,

    //INSTRUMENTS
    //from 100 to 299
    Shovel = 100,
    Pickaxe = 101,

    //RESOURCES
    //from 300 and so on
    Stick = 300,
    Pebbles = 301,
    Rock = 302,
    Clay = 303,
    Seedling = 304
}
