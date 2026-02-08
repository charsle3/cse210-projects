/*
Author: James Kingsley
Purpose: practicing inheritance with a series of breathing activities
Exceeds Expectations:
    - in Reflecting Activity, don't ask questions that have already been asked
    - in Listing Activity, save user input list, and offer to save it externally
*/

using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); //make it neat

        string userInput = "";

        do //menu loop
        {
            Console.Clear();

            Console.WriteLine("Menu:");
            Console.WriteLine("\t1: Start breathing activity");
            Console.WriteLine("\t2: Start listing activity");
            Console.WriteLine("\t3: Start reflecting activity");
            Console.WriteLine("\t4: Quit");  

            Console.Write("\nSelect an activity: "); 
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity(); //make and run breathing activity
                    breathing.Run();
                    break;
                case "2":
                    ListingActivity listing = new ListingActivity(); //make and run listing activity
                    listing.Run();
                    break;
                case "3":
                    ReflectingActivity reflecting = new ReflectingActivity(); //make and run reflecting activity
                    reflecting.Run();
                    break;
            }
        } while(userInput != "4");

        Console.Clear();
    }
}