using System.Runtime.CompilerServices;

public interface ITelemetry
    {
    //Define an interface for Telemetry functionality
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
    }

public class RemoteControlCar
{
    public string? CurrentSponsor { get; private set; }

    private Speed currentSpeed;

    //Create a Telemetry property to access Telemetry functionality
    public ITelemetry Telemetry { get; }

    // Initialize the Telemetry property in the constructor
    public RemoteControlCar()
    {
        Telemetry = new CarTelemetry(this);
    }
    
    //Create a Telemetry class to handle Telemetry-related functionality
    private class CarTelemetry : ITelemetry
    {
        //Passing a reference of the RemoteControlCar instance to the Telemetry class 
        private readonly RemoteControlCar remoteControlCar;
        public CarTelemetry(RemoteControlCar remoteControlCar)
        {
            this.remoteControlCar = remoteControlCar;
        }
        public void Calibrate() {}

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) => remoteControlCar.SetSponsor(sponsorName);

        public void SetSpeed (decimal amount, string unitsString)
            {
                SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
                if (unitsString == "cps")
                    {
                        speedUnits = SpeedUnits.CentimetersPerSecond;
                    }

                remoteControlCar.SetSpeed(new Speed( amount, speedUnits));
            }

    }
    public string GetSpeed()=> currentSpeed.ToString();
    

    private void SetSponsor(string sponsorName)=> CurrentSponsor = sponsorName;

    private void SetSpeed(Speed speed)=> currentSpeed = speed;
}
internal enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

internal struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}



