using System.Security.Cryptography.X509Certificates;

public class GradeSchool
{
    Dictionary<int, List<string>> _roster = new Dictionary<int, List<string>>();
    public bool Add(string student, int grade)
    {
        foreach (var students in _roster.Values)
        {
            if(students.Contains(student))
            {
                return false;
            }
        }

        if (_roster.ContainsKey(grade))
        {
            _roster[grade].Add(student);
        }
        else
        {
            _roster.Add(grade, new List<string> { student });
        }

        return true;
    }

    public IEnumerable<string> Roster()
    {
        List<string> allStudents = new List<string>();
        foreach (var grade in _roster.Keys.OrderBy(g => g))
        {
            foreach (var student in _roster[grade].OrderBy(s => s))
            {
                allStudents.Add(student);
            }
        }
        return allStudents;
    }

    public IEnumerable<string> Grade(int grade)
    {
        List<string> studentsInGrade = new List<string>();
        if (_roster.ContainsKey(grade))
        {
            foreach (var student in _roster[grade].OrderBy(s => s))
            {
                studentsInGrade.Add(student);
            }
        }
        return studentsInGrade;
    }
}