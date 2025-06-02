static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0) return (double) 0/100;
        else if (speed >= 1 && speed <= 4) return (double)100/100;
        else if(speed >= 5 && speed <=8) return (double)90/100;
        else if (speed == 9 ) return (double)80/100;
        else if (speed == 10) return (double)77/100;
        else return (double)0;
    }
    
    public static double ProductionRatePerHour(int speed) => 221 * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) => (int) (ProductionRatePerHour(speed) / 60);
}
