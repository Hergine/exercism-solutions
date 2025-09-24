class RemoteControlCar
{
    private int _distanceDriven;
    private string _batteryLevel = "100";
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        if(_distanceDriven == 2000)
        {
            return "Battery empty";
        }
        else
        {
            return $"Battery at {_batteryLevel}%";
        }
        
    }

    public void Drive()
    {

        if (!(_batteryLevel == "0") && !(_distanceDriven == 2000))
        {
            _distanceDriven += 20;
            _batteryLevel = (int.Parse(_batteryLevel) - 1).ToString();
        }
        else
        {
            _batteryLevel = "Battery empty";
            _distanceDriven = 2000;
        }
    }
}
