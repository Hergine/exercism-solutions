using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        // Check if the identifier is null or empty  
        if (string.IsNullOrEmpty(identifier))
        {
            return string.Empty;
        }
        else
        {
            // Use a StringBuilder to efficiently build the cleaned string  
            StringBuilder cleanedIdentifier = new StringBuilder(identifier);

            //Handle whitespace and control characters
            foreach (var c in identifier)
            {
                // Fixing the invalid ternary operator usage  
                if (Char.IsWhiteSpace(c))
                {
                    cleanedIdentifier.Replace(c, '_');
                }

                else if (Char.IsControl(c))
                {
                    cleanedIdentifier.Replace(c.ToString(), "CTRL");
                }
                else if (!Char.IsLetter(c))
                {
                    cleanedIdentifier.Replace(c.ToString(), "");
                }

            }

            //Handle '-' characters
            for (int i = 0; i < cleanedIdentifier.Length; i++)
            {

                if (cleanedIdentifier[i] == '-')
                {
                    cleanedIdentifier.Remove(i, 1);
                    cleanedIdentifier[i].ToString().ToUpper();
                }

            }

            //Handle greek lowercase characters
            for (int i = 0; i < cleanedIdentifier.Length; i++)
            {
                char[] greekLowercaseAlphabet = new char[]
                  {
                         'α', 'β', 'γ', 'δ', 'ζ', 'η', 'θ',
                         'ι', 'κ', 'λ', 'μ', 'ν', 'ξ', 'ο', 'π',
                         'ρ', 'σ', 'τ', 'υ', 'φ', 'χ', 'ψ', 'ω'
                   };

                foreach (var g in greekLowercaseAlphabet)
                {
                    if (cleanedIdentifier[i] == g)
                    {
                        cleanedIdentifier.Replace(g.ToString(), "");
                    }
                }
            }

            return cleanedIdentifier.ToString();

        }
    }
}
