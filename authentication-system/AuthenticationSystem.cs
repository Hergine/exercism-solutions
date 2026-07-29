using System.Collections.ObjectModel;
using System.Collections.Generic;

public class Authenticator
{
    // Inner helper class defining constants for standard eye colors to avoid magic strings
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }

    // Constructor to set up the Authenticator with an initial admin
    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    // Stores the system administrator identity passed during initialization
    private readonly Identity admin;

    // Pre-populated registry mapping developer names to their Identity details
    private Dictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = EyeColor.Blue
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = EyeColor.Brown
            }
        };

    // Public getter that returns a defensive copy of the admin Identity to prevent external mutation
    public Identity Admin
    {
        get { return new Identity { Email = admin.Email, EyeColor = admin.EyeColor }; }
    }

    // Returns a read-only wrapper around the developers dictionary to prevent outside modification
    public IDictionary<string, Identity> GetDevelopers()
    {
        return new ReadOnlyDictionary<string, Identity>(developers);
    }
}

// Data structure representing a user's identity details
public struct Identity
{
    public string Email { get; set; }

    public string EyeColor { get; set; }
    
}
