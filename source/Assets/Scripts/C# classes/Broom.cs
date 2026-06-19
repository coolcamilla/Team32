using UnityEngine;

public class Broom : Instrument
{
    public Broom()
    {
        Damage = 1;
        InstrumentSprite = Resources.Load<Sprite>("Visuals/Sprites/Instruments/Broom");
    }

    protected override void AddCraftResources()
    {
        
    }
}
