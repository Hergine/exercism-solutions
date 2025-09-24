class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[]{ 0, 2, 5, 3, 7, 8, 4 };
        ;
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        int result = Array.IndexOf(birdsPerDay, 0);
        if (result == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int result = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            result += birdsPerDay[i];
        }
        return result;
    }

    public int BusyDays()
    {
        int result = 0;
        foreach(int i in birdsPerDay)
        {
            if (i >= 5)
            {
                result++;
            }
        }
        return result;
    }
}
