// TODO: define the 'LogLevel' enum
enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0,
}
static class LogLine
{
    
    public static LogLevel ParseLogLevel(string logLine)
    {
        switch (logLine)
        {
            case string s when s.Contains("[TRC]"):
                return LogLevel.Trace;
            case string s when s.Contains("[DBG]"):
                return LogLevel.Debug;
            case string s when s.Contains("[INF]"):
                return LogLevel.Info;
            case string s when s.Contains("[WRN]"):
                return LogLevel.Warning;
            case string s when s.Contains("[ERR]"):
                return LogLevel.Error;
            case string s when s.Contains("[FTL]"):
                return LogLevel.Fatal;
            default:
                return LogLevel.Unknown;
            
        }
        
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}
