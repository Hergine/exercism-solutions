static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.TryParse(appointmentDateDescription, out DateTime appointmentDate)
            ? appointmentDate
            : throw new ArgumentException("Invalid date format. Please use 'yyyy/d/d' HH/MM/SS.");
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        var now = DateTime.Now;
        if(appointmentDate < now)
        {
            return true;
        }
        else if (appointmentDate > now)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var time = appointmentDate.TimeOfDay;
        if ((time.Hours >= 12 && time.Hours <18))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string Description(DateTime appointmentDate)
    {
        return("You have an appointment on " + appointmentDate.ToString("M/d/yyyy h:mm:ss tt") + ".");
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0, 0);
    }
}
