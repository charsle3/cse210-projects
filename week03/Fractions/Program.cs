using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction myFraction = new Fraction();
                
        Fraction myFractionWhole = new Fraction(6);

        Fraction myFractionBoth = new Fraction(6, 7);

        myFraction.SetBottom(2);
        myFraction.SetTop(2);

        Console.WriteLine(myFraction.GetFractionString());
        Console.WriteLine(myFractionWhole.GetFractionString());
        Console.WriteLine(myFractionBoth.GetFractionString());

        Console.WriteLine(myFractionBoth.GetDecimalValue());
    }
}