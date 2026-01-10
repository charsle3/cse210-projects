using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int newNumber = 0;
        int biggest = 0;
        int smallest = 999;
        Console.WriteLine("Enter a List of numbers. Type 0 when finished.");

        do
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            newNumber = int.Parse(input);
            if (newNumber != 0)
            {
                numbers.Add(newNumber);
                if (newNumber > biggest)
                {
                    biggest = newNumber;
                }
                
                if (newNumber < smallest)
                {
                    smallest = newNumber;
                }
            }
            
        } while (newNumber != 0);

        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        int average = sum / numbers.Count;

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The biggest number is {biggest}");
        Console.WriteLine($"The smallest is {smallest}");
    }
}