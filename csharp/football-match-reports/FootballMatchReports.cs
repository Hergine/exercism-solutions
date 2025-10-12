public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3 or 4:
                return "center back";
            case 5:
                return "right back";
            case 6 or 7 or 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
        }
    }

    public static string AnalyzeOffField(object report)
    {
        if (report is int)
        {
            return $"There are {report} supporters at the match.";
        }
        else if (report is string)
        {
            return $"{report}";
        }
        else if (report is Incident)
        {
            Incident incident = (Incident)report;
            return $"{incident.GetDescription()}";
        }
        else if (report is Injury)
        {
            Injury injury = (Injury)report;
            return $"Oh no!{injury.GetDescription()} Medics are on the field.";
        }
        else if (report is Manager)
        {
            Manager manager = (Manager)report;
            if (manager.Club is null)
                return $"{manager.Name}";
            return $"{manager.Name} ({manager.Club ?? null})";
        }
        else
        {
            return string.Empty;
        }
    }
}
