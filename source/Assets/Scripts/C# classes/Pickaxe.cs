using UnityEditor;
using UnityEngine;

public class Pickaxe : Instrument
{
    public Pickaxe()
    {
        Damage = 5;
        InstrumentSprite = Resources.Load<Sprite>("Visuals/Sprites/Instruments/Pickaxe");
    }

    protected override void AddCraftResources()
    {
        _resourcesToCraft.Add(CraftMaterial.Stick, 5);
        _resourcesToCraft.Add(CraftMaterial.Stone, 5);
    }
}
