
static class LogLine
{
    public static string Message(string logLine)
    {
        int discard = logLine.IndexOf(":") + 1;
        return logLine.Substring(discard).Trim();
    }

    public static string LogLevel(string logLine)
    {
        int start = logLine.IndexOf("[");
        int end = logLine.IndexOf("]");
        return logLine.Substring(start + 1, (end - start) - 1).ToLower();
    }

    public static string Reformat(string logLine)
    {
        string result = Message(logLine);

        string resultOne = LogLevel(logLine);

        return $"{result} ({resultOne})";

    }
}
