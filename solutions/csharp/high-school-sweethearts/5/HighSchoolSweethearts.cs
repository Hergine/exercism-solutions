using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA, 29} ♡ {studentB, -29}";
    }

    public static string DisplayBanner(string studentA, string studentB)
{
    static string Initials(string name) =>
        string.Join(" ",
            name.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => $"{n[0]}."));

    return
@$"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {Initials(studentA)}  +  {Initials(studentB)}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";
}

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        //Display date and hours in German format
        CultureInfo germanCulture = new CultureInfo("de-DE");
        string formattedDate = start.ToString("d", germanCulture);
        string formattedHours = hours.ToString("N2", germanCulture);

        return $"{studentA} and {studentB} have been dating since {formattedDate} - that's {formattedHours} hours";
        
    }
}
