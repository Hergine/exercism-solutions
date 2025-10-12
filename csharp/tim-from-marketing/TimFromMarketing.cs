static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        if (id == null && department == null)
        {
            return $"{name} - OWNER";
        }
        if (id == null)
        {
            return $"{name} - {department?.ToUpper()}";
        }
        if (department == null)
        {
            return $"[{id}] - {name} - OWNER";
        }
        
            return $"[{id}] - {name} - {department.ToUpper()}";
    }
}
