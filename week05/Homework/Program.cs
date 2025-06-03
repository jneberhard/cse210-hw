using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        string summary = assignment.GetSummary();
        Console.WriteLine();
        Console.WriteLine(summary);
        Console.WriteLine();

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions","7.3", "8-19");
        string mathSummary = mathAssignment.GetSummary();
        string assignment1 = mathAssignment.GetHomeworkList();
        Console.WriteLine(mathSummary);
        Console.WriteLine(assignment1);
        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        string writingSummary = writingAssignment.GetSummary();
        string bookTitle = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingSummary);
        Console.WriteLine(bookTitle);
        Console.WriteLine();


    }
}