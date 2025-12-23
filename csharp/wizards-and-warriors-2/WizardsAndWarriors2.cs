static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        return travelMethod switch
        {
            TravelMethod.Walking => "You're traveling to your destination by walking.",
            TravelMethod.Horseback => "You're traveling to your destination on horseback.",
            _ => "Unknown travel method."
        };
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        return $"{Describe(character)} {Describe(travelMethod)} You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(Character character, Destination destination)
    {
        return $"{Describe(character)} {Describe(TravelMethod.Walking)} You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }
}

class Character
{
    public string? Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string? Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}
