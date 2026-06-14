public static class Equipment
{
    private static Instrument _currentInstrument;

    public static Instrument CurrentInstrument
    {
        get
        {
            if (_currentInstrument == null)
                _currentInstrument = new Broom(); 
            return _currentInstrument;
        }
        private set => _currentInstrument = value;
    }

    public static void Equip(Instrument instrument)
    {
        CurrentInstrument = instrument;
    }
}