class WeighingMachine
{
    private double _weight;
    private readonly double _precision;

    public WeighingMachine(double precision)
    {
        _precision = precision;
    } 
    
    // TODO: define the 'Precision' property
    public double Precision
    {
        get => _precision;
    } 

    // TODO: define the 'Weight' property
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                _weight = value;
            }
        }
    }

    // TODO: define the 'DisplayWeight' property
   public string DisplayWeight
    {
       // get the weight adjusted by the tare adjustment and rounded to the precision
         get
         {
                double adjustedWeight = (Weight / _precision * _precision) - TareAdjustment;
                //double roundedWeight = adjustedWeight / _precision * _precision;
                return adjustedWeight.ToString($"F{Precision}") + " kg";
         }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment {get; set; } = 5.0;
    
}
