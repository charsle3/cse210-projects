/* 
Author: James Kingsley
Purpose: practice polymorphism by creating a gamified goal accomplishing program
Exceeds Expectations:
    - every user input on a menu is validated. (in retrospect for best practices I should have made an 'InputValidation' function but it works as is)
    - gamification: user collects tickets from completing goals, so as to buy equipment from List<string> _rewards, in order to face the dragon. (of course purchased equipment is saved as well as goals)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("What is your username? ");
        string username = Console.ReadLine();
        bool exists = false;

        if (File.Exists($"{username}.txt")) //check whether save file already exists
        {
            exists = true;
        }
        
        GoalManager manager = new GoalManager(username, exists); //constructor will load save file if it exists

        manager.Start();
    }
}