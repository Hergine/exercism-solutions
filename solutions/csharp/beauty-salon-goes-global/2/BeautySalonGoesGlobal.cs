using System.Runtime.InteropServices;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    //Convert UTC time to local time 
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    //Convert local time to UTC time
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        //Find the OS FOR the correct timezone ID and convert the local time to UTC time
        DateTime utcTime;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            TimeZoneInfo timeZone = location switch
            {
                Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
                Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
                Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time"),
                _ => throw new ArgumentException("Invalid location")
            };
            utcTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), timeZone);
        }

        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            TimeZoneInfo timeZone = location switch
            {
                Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
                Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
                Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
                _ => throw new ArgumentException("Invalid location")
            };
            utcTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), timeZone);
        }
        else
        {
            throw new PlatformNotSupportedException("Unsupported operating system");
        }
        return utcTime;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentException("Invalid alert level")
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        //Store the timezone info based on the OS and location
        TimeZoneInfo timeZone_result;

        //Find the OS FOR the correct timezone ID 
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            TimeZoneInfo timeZone = location switch
            {
                Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
                Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
                Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time"),
                _ => throw new ArgumentException("Invalid location")
            };
            timeZone_result = timeZone;
        }

        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            TimeZoneInfo timeZone = location switch
            {
                Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
                Location.London => TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
                Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
                _ => throw new ArgumentException("Invalid location")
            };
            timeZone_result = timeZone; 
        } 
        else
        {
            throw new PlatformNotSupportedException("Unsupported operating system");
        }

        //Convert the UTC time to local time and check if daylight saving time has changed
        DateTime dtLocal = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone_result);
        bool isDaylightSavingNow = timeZone_result.IsDaylightSavingTime(dtLocal);
        bool wasDaylightSavingBefore = timeZone_result.IsDaylightSavingTime(dtLocal.AddDays(-7));

        //Return true if daylight saving time has changed, otherwise return false   
        return isDaylightSavingNow != wasDaylightSavingBefore;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        //Store the culture info based on the location
        CultureInfo cultureInfo;

        cultureInfo = location switch
        {
            Location.NewYork => System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            Location.London => System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
            Location.Paris => System.Globalization.CultureInfo.GetCultureInfo("fr-FR"),
            _ => throw new ArgumentException("Invalid location")
        };

        //Check if the input string is in a valid format for the specified culture
        if (!DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out DateTime dt))
        {
            //return {1, 1, 1, 0, 0, 0} if the input string is not in a valid format for the specified culture
            return new DateTime(1, 1, 1, 0, 0, 0);    
        }
        return dt;
    }
}
