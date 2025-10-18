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
        return report switch
        {
            int supporters => $"There are {supporters} supporters at the match.",
            string message => message,
            Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
            Incident incident => incident.GetDescription(),
            Manager manager when manager.Club is null => manager.Name,
            Manager manager => $"{manager.Name} ({manager.Club})",
            _ => string.Empty
        };
    }
}
