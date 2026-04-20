using System;

class Student
{
    public string Name { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
    public int Grade3 { get; set; }

    public Student(string name, int g1, int g2, int g3)
    {
        Name = name;
        Grade1 = ValidateGrade(g1);
        Grade2 = ValidateGrade(g2);
        Grade3 = ValidateGrade(g3);
    }

    private int ValidateGrade(int grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100");
        return grade;
    }

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverage();

        if (avg >= 90) return "A";
        if (avg >= 75) return "B";
        if (avg >= 60) return "C";
        return "F";
    }

    public void Print()
    {
        Console.WriteLine($"{Name}: Avg = {GetAverage():F2}, Grade = {GetLetterGrade()}");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[]
        {
            new Student("Saida", 90, 85, 88),
            new Student("Symbat", 70, 75, 72),
            new Student("Aisha", 95, 92, 96),
            new Student("Diana", 60, 65, 58)
        };

        foreach (var s in roster)
        {
            s.Print();
        }

        // Find best student
        Student best = roster[0];

        foreach (var s in roster)
        {
            if (s.GetAverage() > best.GetAverage())
                best = s;
        }

        Console.WriteLine($"\nBest student: {best.Name} with avg {best.GetAverage():F2}");
    }
}
