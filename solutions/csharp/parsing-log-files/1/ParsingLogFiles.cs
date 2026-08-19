using System.Text.RegularExpressions;
public class LogParser
{
    public bool IsValidLine(string text)
    {
        //Determining if text contains exercism [TRC][DBG][INF][WRN][ERR][FTL] todetermine validity using Regex
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    }

    public string[] SplitLogLine(string text)
    {
        //Splitting the Log files that contains a first character 
        // of "<" and a last character of ">" and any combination of 
        // the following characters "^", "*", "=" and "-" in between
        //replacing them with a comma and splitting the string into an array of strings
        //in one go
        
        //Regex pattern to match the specified format
        string pattern = @"<[\^*=-]*>";

        //Replace the matched pattern with a comma
        string replacedText = Regex.Replace(text, pattern, ",");

        //Split the modified string into an array of strings using the comma as a delimiter
        return replacedText.Split(',');
    }

   public int CountQuotedPasswords(string lines)
{
    return Regex.Matches(
        lines,
        "\".*password.*\"",
        RegexOptions.IgnoreCase
    ).Count;
}

    public string RemoveEndOfLineText(string line)
    {
        //Removing the end of line text from the given line using Regex
        //The end of line text has a line number without intervening spaces
        //and replace it by a clean string
        return Regex.Replace(line, @"end-of-line\d+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        //examining each line in the given array of lines to check if it contains an offended password.
        //If so, print it plus the full line
        //If not, print --------: [complete line].
        //Lines with quoted passwords have already been removed and you process lines irrespective of 
        // whether they are valid
        //The offended password is defined as a string that contains the word "password" and concatenated with any other characters, excluding spaces.
        string[] result = new string[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];

        Match match = Regex.Match(line, @"password\S+", RegexOptions.IgnoreCase);

        if (match.Success)
        {
            result[i] = match.Value + ": " + line;
        }
        else
        {
            result[i] = "--------: " + line;
        }
    }

    return result;
    }
}
