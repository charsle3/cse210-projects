using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("John Smith", "Humanitites 101");

        Console.WriteLine(myAssignment.GetSummary());

        Console.WriteLine();

        MathAssignment myMathAssignment = new MathAssignment("John Smith", "Calculus", "6.9", "4-20");

        Console.WriteLine(myMathAssignment.GetSummary());
        Console.WriteLine(myMathAssignment.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment myWritingAssignment = new WritingAssignment("John Smith", "History of the Aglet", "The Most Useful, Yet Tragically Unappreciated Invention");

        Console.WriteLine(myWritingAssignment.GetSummary());
        Console.WriteLine(myWritingAssignment.GetWritingInformation());
    }
}