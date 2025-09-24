
public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string word, string dismiss) => word.Substring(word.IndexOf(dismiss[0]) + dismiss.Length);


    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string word, string start, string end) => word.Substring(word.IndexOf(start) + start.Length, word.IndexOf(end) - word.IndexOf(start) - start.Length);


    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string word) => word.SubstringAfter(": ");
    

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string word) => word.SubstringBetween("[", "]");   

}