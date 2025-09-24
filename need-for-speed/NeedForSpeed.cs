using Microsoft.VisualStudio.TestPlatform.Utilities;

class RemoteControlCar
{
    private int _speed;
    private int _batteryDrain;
    private int _batteryPercentage = 100; //Cars start with full (100%) batteries
    private int _distanceDriven;
    
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this._speed = speed;
        this._batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        if(_batteryPercentage < _batteryDrain)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if(_batteryPercentage >= _batteryDrain)
        {
            _distanceDriven += _speed;
            _batteryPercentage -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}

class RaceTrack
{
    private int _distance;
    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        this._distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.BatteryDrained() != true)
        {
            car.Drive();
        }

        if (car.DistanceDriven() >= _distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
