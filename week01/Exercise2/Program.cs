using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? (no symbol) ");
        string input = Console.ReadLine();

        int grade = int.Parse(input);
        string letter;
        string plusminus = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        if ((grade % 10) >= 7 && !(letter == "A" || letter == "F"))
        {
            plusminus = "+";
        }
        else if ((grade % 10) < 3 && letter != "F")
        {
            plusminus = "-";
        }

        Console.WriteLine($"Your letter grade is {letter}{plusminus}.");

        if (grade >= 70)
        {
            Console.WriteLine("You passed the class! Congratulations!");
        }
        else
        {
            Console.WriteLine("Good luck next time! Remember, tutors are free!");
        }
    }
} 