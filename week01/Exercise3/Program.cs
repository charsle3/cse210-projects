using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        int guess;

        do
        {
        Console.Write("What is your guess? ");
        string guessinput = Console.ReadLine();
        guess = int.Parse(guessinput);

        if (guess > number)
        {
            Console.WriteLine("Lower");
        }
        else if (guess < number)
        {
            Console.WriteLine("Higher");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
        } while (guess != number);
    }
}