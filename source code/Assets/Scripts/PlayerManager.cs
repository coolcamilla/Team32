using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Instrument _instrument;

    public Instrument CurrentInstrument { get { return _instrument; } }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _instrument = new Broom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        CraftManager.OnItemCrafted += ChangeInstrument;
    }

    private void OnDisable()
    {
        CraftManager.OnItemCrafted -= ChangeInstrument;
    }

    public void ChangeInstrument(Instrument newInstrument)
    {
        _instrument = newInstrument;
    }

}
