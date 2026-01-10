using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("\nWhat is your first name? ");
        string FirstName = Console.ReadLine();

        Console.Write("\nWhat is your last name? ");
        string LastName = Console.ReadLine();

        Console.WriteLine();

        Console.WriteLine($"Your name is {LastName}. {FirstName} {LastName}.\n");
    }
}