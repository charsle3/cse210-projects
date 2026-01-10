using System;

class Program
{
    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome, etc. etc.");
        }

    static string PromptUserName()
    {
        Console.Write("Please enter name: ");
        string username = Console.ReadLine();

        return username;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter favorite whole number: ");
        string userInput = Console.ReadLine();
        int userNumber = int.Parse(userInput);

        return userNumber;
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void DisplayResult(string name, int number)
    {
        Console.WriteLine($"{name}, the square of your number is {number}");
    }

    static void Main(string[] args)
    {
        
        DisplayWelcome();

        string userName = PromptUserName();

        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }
}