static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float interestRate = balance switch
        {
            < 0 => 3.213f,
            >= 0 and < 1000 => 0.5f,
            >= 1000 and < 5000 => 1.621f,
            _  => 2.475f
        };
        return interestRate;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (decimal)InterestRate(balance) / 100;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return Interest(balance) + balance;
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
          balance += Interest(balance);
            years++;
        }
        return years;
        
    }
}
