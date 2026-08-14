using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA, 29} ♡ {studentB}, -29";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        static string Initials (string name) => name.Split(' ').Select(n => n[0]).Aggregate("", (a, b) => $"{a}. {b}. ");
        static string Repeat(string s, int n) => string.Join("", Enumerable.Repeat(s, n));
        return 
        
        @$"{Repeat("*", 6), 6}{Repeat("*", 6), 19}
        {Repeat("*", 2), 4}{Repeat("*", 2), 12}{Repeat("*", 2), 17}{Repeat("*", 2), 24}}}
        {Repeat("*", 2), 2}{Repeat("*", 2), 13}{Repeat("*", 2), 15}{Repeat("*", 2), 26}
        {Repeat("*", 2), 1}{Repeat("*", 2), 15}{Repeat("*", 2), 27}
        {Repeat("*", 2), 1}{Repeat("*", 2), 27}
        {Repeat("*", 2), 1}{Initials(studentA)} +  {Initials(studentB)}{Repeat("*", 2), 27}
        {Repeat("*", 2), 2}{Repeat("*", 2), 26}
        {Repeat("*", 2), 4}{Repeat("*", 2), 24}
        {Repeat("*", 2), 6}{Repeat("*", 2), 22}
        {Repeat("*", 2), 8}{Repeat("*", 2), 20}
        {Repeat("*", 2), 10}{Repeat("*", 2), 18}
        {Repeat("*", 2), 12}{Repeat("*", 2), 16}
        {Repeat("*", 3), 14}
         {Repeat("*", 1), 15}
        ";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        //Display date and hours in German format
        CultureInfo germanCulture = new CultureInfo("de-DE");
        string formattedDate = start.ToString("d", germanCulture);
        string formattedHours = hours.ToString("F2", germanCulture);

        return $"{studentA} and {studentB} have been dating since {formattedDate} - that's {formattedHours} hours.";
        
    }
}
