using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base assignment
        Assignment generalAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(generalAssignment.GetSummary());

        // Create a math assignment
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Create a writing assignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
