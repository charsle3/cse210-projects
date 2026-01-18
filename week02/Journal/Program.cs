using System;

/*
Author: 
James Kingsley

Purpose: 
Create a journal program capable of making entries (including one random prompt and the date), displaying entries, saving and loading to external files. Intended to act as practice for abstraction.

Exceeds Expectations:
1. Double check user input in menu to ensure a valid integer is input. 
2. Check whether the file to load exists before loading it.
3. Upon quitting the program or loading an external save, check whether there are unsaved files and give the user the option to go back and save them.
4. Only save a new entry if there is content.
5. Remembers most recently used external file, to help user remember where to save or load  to / from.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        int choice = 0;

        do
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write new Entry");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("Your choice: ");
            string input = Console.ReadLine();

            bool isInt = int.TryParse(input, out choice); //check that the input is in fact a valid integer (Exceeds expectations)

            if (isInt)
            {
                switch (choice)
                {
                    case 1:
                        myJournal.AddEntry();
                        break;

                    case 2:
                        myJournal.DisplayAll();
                        break;

                    case 3:
                        Console.Write("Please input the name for the save file (no extention): ");
                        if (myJournal._mostRecentFile != "")
                        {
                            Console.WriteLine($"\n(Recently used file location: {myJournal._mostRecentFile})"); //help the user remember where they saved or loaded their journal from / to. (exceeds expectations)
                        }
                        string saveFileName = Console.ReadLine();

                        saveFileName = saveFileName + ".txt";

                        myJournal.SaveToFile(saveFileName);
                        break;
                        
                    case 4:
                        
                        Console.Write("Please input the name for the load file (no extention): ");
                        if (myJournal._mostRecentFile != "")
                        {
                            Console.WriteLine($"\n(Recently used file location: {myJournal._mostRecentFile})"); //help the user remember where they saved or loaded their journal from / to. (exceeds expectations)
                        }
                        string loadFileName = Console.ReadLine();

                        loadFileName = loadFileName + ".txt";

                        if (myJournal._saved) //Check whether there are unsaved entries before loading (exceeds expectations)
                        {
                            myJournal.LoadFromFile(loadFileName);
                        }
                        else
                        {
                            Console.Write("Loading a file will erase unsaved entries. Load anyway? (y/n) "); //give user the choice to go back and save
                            string saveCheck = Console.ReadLine();

                            if (saveCheck.ToLower() == "yes" || saveCheck.ToLower() == "y")
                            {
                                    myJournal.LoadFromFile(loadFileName);
                            }
                        }
                        
                        break;

                    case 5:
                        if (myJournal._saved) //Check whether the file has been saved before exiting (exceeds expectations)
                        {
                            Console.WriteLine("Thanks for writing in your journal!");
                        }
                        else
                        {
                            Console.Write("You didn't save. Want to exit anyway? (y/n) "); //give user the choice to go back and save
                            string saveCheck = Console.ReadLine();

                            if (saveCheck.ToLower() == "yes" || saveCheck.ToLower() == "y")
                            {
                                Console.WriteLine("Thanks for writing in your journal!");
                            }
                            else
                            {
                                choice = 0;
                            }
                        }
                        break;

                    default:

                        Console.WriteLine("Please input 1, 2, 3, 4, or 5, no periods, no commas."); //if it isn't a valid choice
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please input 1, 2, 3, 4, or 5, no periods, no commas."); //if it isn't an integer
            }

            Console.WriteLine();

        }while(choice != 5);
    }
}
