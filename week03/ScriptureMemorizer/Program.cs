/*
Author: James Kingsley

Purpose: create a scripture memorizing aid, and practice encapsulation.

exceeds expectations:
- don't hide already hidden words
- pick random scripture (from list of three) every time program is run

*/

using System;

class Program
{
    static void Main(string[] args)
    {
        bool done = false;
        string userInput = "";
        Random random = new Random(); //these variable are used later in the loop so we want this scope

        Reference angelReference = new Reference("2 Nephi", 32, 3);

        Scripture angel = new Scripture(angelReference, "3. Angels speak by the power of the Holy Ghost; wherefore, the speak the words of Christ. Wherefore I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.");

        Reference prayReference = new Reference("2 Nephi", 32, 8, 9);

        Scripture pray = new Scripture(prayReference, "8. And now, my beloved brethren, I perceive that ye ponder still in your hearts; and it grieveth me that I must speak concerning this thing. For if ye would hearken unto the Spirit which teacheth a man to pray, ye would know that ye must pray; for the evil spirit teacheth not a man to pray, but teacheth him that he must not pray.\n9. But behold, I say unto you that ye must pray always, and not faint; that ye must not perform any thing unto the Lord save in the first place ye shall pray unto the Father in the name of Christ, that he will consecrate thy performance unto thee, that thy performance may be for the welfare of thy soul");

        Reference lightReference = new Reference("Mattew", 5, 14, 16);

        Scripture light = new Scripture(lightReference, "14. Ye are the light of the world. A city that is set on an hill cannot be hid.\n15. Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house.\n16. Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven");

        Scripture myScripture = angel; //myScripture needs to be initialized to something to build successfully
        int randomScripture = random.Next(1, 4); //select random scripture to memorize (exceeds expectations)

        switch (randomScripture)
        {
            case 1:
                myScripture = angel;
                break;
            case 2:
                myScripture = pray;
                break;
            case 3:
                myScripture = light;
                break;
        }
        

        do
        {
            Console.Clear(); //clear the terminal

            Console.WriteLine(myScripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to continue, or type 'quit' to finish. ");
            userInput = Console.ReadLine();

            if (myScripture.IsCompletelyHidden()) 
            //check if everything's hidden BEFORE running the hide command (ensures last word to be hidden is displayed before program ends.)
            {
                done = true;
            }

            if (userInput == "quit")
            {
                done = true;
            }
            else //if the input isn't quit, run the hide command.
            {
                int numberToHide = random.Next(1,4);
                myScripture.HideRandomWords(numberToHide); 
            }

        } while(!done);
    }
}