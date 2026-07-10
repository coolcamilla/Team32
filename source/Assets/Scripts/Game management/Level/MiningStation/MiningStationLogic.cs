public class MiningStationLogic
{
    private readonly float _miningInterval;
    private float _timer;

    public MiningStationLogic(float miningInterval)
    {
        _miningInterval = miningInterval;
        _timer = 0f;
    }

    public bool Tick(float deltaTime)
    {
        _timer += deltaTime;
        if (_timer >= _miningInterval)
        {
            _timer = 0f;
            return true;
        }
        return false;
    }
}