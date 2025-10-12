public class Player
{
    private static readonly Random _random = new Random();

    public int RollDie()
    {
        return _random.Next(1, 19);
    }

    // Simulates generating a spell strength between 0.0 and 100.0
    public double GenerateSpellStrength()
    {
        return new Random().NextDouble() * 100.0;
    }
}
