public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? obj)
    {
        // check if obj is the correct type and cast it to 'other'
        return obj is FacialFeatures other &&
               EyeColor == other.EyeColor &&
               PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        // Combine the hash codes of the properties to create a unique hash for this data
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? obj)
    {
        return obj is Identity other &&
               Email == other.Email &&
               FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly HashSet<Identity> _registeredIdentities = new HashSet<Identity>();

    private static readonly Identity Admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(Admin);
    }

    public bool Register(Identity identity)
    {
        return _registeredIdentities.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return _registeredIdentities.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return ReferenceEquals(identityA, identityB);
    }
}
