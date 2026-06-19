using UnityEditor;
using UnityEngine;

public class Shovel : Instrument
{
    public Shovel()
    {
        Damage = 3;
        InstrumentSprite = Resources.Load<Sprite>("Visuals/Sprites/Instruments/WoodenShovel");
    }

    protected override void AddCraftResources()
    {
        _resourcesToCraft.Add(CraftMaterial.Stick, 10);
    }
}
