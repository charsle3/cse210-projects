public class GoalManager
{
    private string _userName;
    private int _currency;
    List<Goal> _goals = new List<Goal>();
    List<string> _rewards = new List<string>(); //things to purchase
    List<string> _purchased = new List<string>(); //purchased items

    public GoalManager(string userName, bool exists)
    {
        _userName = userName; //also used for save and load files
        _currency = 0;

        _rewards.Add("Sword"); //hard coded rewards list
        _rewards.Add("Armor");
        _rewards.Add("Shield");
        _rewards.Add("Health Potion");

        if (exists) //if save file exists (checked by Main()) load up the save file
        {
            LoadGoals();
        }
    }

    public void Start() //menu loop
    {
        bool quit = false;

        Console.Clear(); //make it neat

        Console.WriteLine($"Welcome to Eternal Quest, {_userName}!"); //welcome message, happens once
        Thread.Sleep(3000); //3sec is standard pause time
        Console.Clear();

        do
        {
            int userChoice = 0;
            bool success = false;

            do //exceeds: validate user input with a loop
            {
                Console.Clear();

                DisplayPlayerInfo();
                Console.WriteLine("\nPlease make a selection: ");
                Console.WriteLine("\t1. Display goals");
                Console.WriteLine("\t2. Create new goal");
                Console.WriteLine("\t3. Record event");
                Console.WriteLine("\t4. Redeem tickets");
                Console.WriteLine("\t5. Display current equipment");
                Console.WriteLine("\t6. Slay dragon");
                Console.WriteLine("\t7. Quit");
                Console.Write(": ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice)) //exceeds: make sure a number was used
                {
                    if (choice > 7 || choice < 1) //exceeds: make sure a valid choice was made
                    {
                        Console.WriteLine("Please enter a valid menu choice, between 1 and 6.");
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        userChoice = choice;
                        success = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu choice, between 1 and 6.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }while(!success);

            switch (userChoice)
            {
                case 1:
                    ListGoalDetails();
                    break;
                case 2:
                    CreateGoal();
                    break;
                case 3:
                    RecordEvent();
                    break;
                case 4:
                    if (_currency >= 500 && _rewards.Count > 0) //check if they have the money, and if there's anything to buy
                    {
                        Console.Clear();
                        ListRewards();
                        Console.Write("Please select reward. Each Reward costs 500 tickets: ");
                        if (int.TryParse(Console.ReadLine(), out int input)) //exceeds: make sure a number was used
                        {
                            if (input > _rewards.Count || input < 1) //exceeds: make sure a valid choice was made
                            {
                                Console.WriteLine("That is not a valid reward");
                            }
                            else
                            {
                                RedeemReward(input - 1); //input is used for list index, so decrement by one
                                Console.WriteLine("Thank you for your purchase! ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid reward");
                        }
                    }
                    else
                    {
                        if (_rewards.Count > 0)
                        {
                            Console.WriteLine("You do not have enough tickets, sorry."); //not enough money
                        }
                        else
                        {
                            Console.WriteLine("You have already purchased everything!"); //empty list
                        }
                    }
                    break;
                case 5:
                    if (_purchased.Count > 0)
                    {
                        ListEquipment();
                    }
                    else
                    {
                        Console.WriteLine("You have no equipment currently. Complete goals to earn tickets!");
                    }
                    break;
                case 6:
                    if (_rewards.Count == 0) //only display if all equipment has been purchased
                    {
                        string storyPartOne = "Armored, armed, and ready for battle, our hero sets out to fulfill their destiny! They have passed through much tribulation, overcoming the steepest of odds to arrive here, before the cave of the dragon.";

                        ReadSlow(storyPartOne, 50); //string is broken up so it can be read slowly and dramatically

                        string pause = " . . .";

                        ReadSlow(pause, 300);
                        Console.WriteLine();

                        string storyPartTwo = " Through fire and flames! Under tooth and nail! By claw and sword the two fought, until at last the dragon was vanquished!";

                        ReadSlow(storyPartTwo, 25);
                        ReadSlow(pause, 300);

                        string storyFinal = " But there's always another dragon.";

                        ReadSlow(storyFinal, 100);
                        Thread.Sleep(3000);

                        Console.WriteLine($"\nGood luck. part II coming soon.\nFinal score: {_currency}"); //the quest is eternal after all. ;)
                        Thread.Sleep(3000);
                        
                    }
                    else
                    {
                        Console.WriteLine("You are not ready to face the dragon. You still need to purchase;");
                        ListRewards();
                    }
                    break;
                case 7:
                    Console.WriteLine("Thank you. Goodbye.");
                    SaveGoals();
                    quit = true;
                    break;
            }

            Thread.Sleep(3000);
        }while(!quit);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"{_userName} has {_currency} tickets");
    }

    public void ListGoalDetails()
    {
        int i = 1;

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetails()}");
            i++;
        }
    }

    public void ListRewards() //exceeds: list equipment remaining for purchase
    {
        int i = 1;

        foreach (string reward in _rewards)
        {
            Console.WriteLine($"{i}. {reward}");
            i++;
        }
    }

    public void ListEquipment() //exceeds: list current equipment
    {
        int i = 1;

        foreach (string item in _purchased)
        {
            Console.WriteLine($"{i}. {item}");
            i++;
        }
    }

    public void RedeemReward(int choice) //exceeds: move equipment from rewards list to purchased, take payment
    {
        _purchased.Add(_rewards[choice]);

        _rewards.RemoveAt(choice);

        _currency -= 500;
    }

    public void ReadSlow(string story, int speed) //exceeds: used to slowly display victory message
    {
        foreach (char c in story)
        {
            Console.Write(c);
            Thread.Sleep(speed);
        }
    }

    public void CreateGoal() 
    {
        int userChoice = 0;
        bool success = false;

        do //exceeds: validate user input with a loop
        {
            Console.WriteLine("Please specify type of goal:");
            Console.WriteLine("\t1. Simple (one and done)");
            Console.WriteLine("\t2. Eternal (repeats forever)");
            Console.WriteLine("\t3. Checkist (repeat a certain number of times)");
            Console.Write(": ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice)) //exceeds: make sure a number was used
            {
                if (choice > 3 || choice < 1) //exceeds: make sure a valid choice was made
                {
                    Console.WriteLine("Please enter a valid menu choice, 1, 2, or 3.");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    userChoice = choice;
                    success = true;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid menu choice, 1, 2, or 3.");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }while(!success);

        Console.Write("What is the goal called? ");
        string goalName = Console.ReadLine();

        Console.Write("Please enter a short description of the goal: ");
        string description = Console.ReadLine();

        Console.WriteLine("How much is the goal worth?");
        Console.WriteLine("(easy -- around 50 tickets)");
        Console.WriteLine("(moderate -- around 100 tickets)");
        Console.WriteLine("(hard -- around 150 tickets)");
        Console.Write(": ");
        int tickets = int.Parse(Console.ReadLine());


        switch (userChoice)
        {
            case 1:
                _goals.Add(new SimpleGoal(goalName, description, tickets));
                break;

            case 2:
                _goals.Add(new EternalGoal(goalName, description, tickets));
                break;

            case 3:
                Console.Write("How many times do you need to do this goal? "); 
                int target = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(goalName, description, tickets, target));
                break;

            default:
                break;
        }
        
    }

    public void RecordEvent()
    {
        int userChoice = 0;
        bool success = false;

        do //exceeds: validate user input with a loop
        {
            Console.WriteLine("Your current goals are:");
            ListGoalDetails();

            Console.Write("For which goal is this event? ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice)) //exceeds: make sure a number was used
            {
                if (choice > _goals.Count || choice < 1) //exceeds: make sure a valid choice was made
                {
                    Console.WriteLine("Please enter a valid menu choice");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else
                {
                    userChoice = choice - 1;
                    success = true;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid menu choice");
                Thread.Sleep(3000);
                Console.Clear();
            }
        }while(!success);
        
        if (!_goals[userChoice].IsComplete())
        {
            int tickets = _goals[userChoice].RecordEvent();

            _currency += tickets;

            Console.WriteLine($"Congratulations! You have earned {tickets} tickets!");
        }
        else
        {
            Console.WriteLine("That goal is already complete.");
        }
        
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter($"{_userName}.txt")) //save info, variables separated by '|'
        {
            outputFile.WriteLine($"currency|{_currency}");
            
            foreach (Goal goal in _goals) //save current goals
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

           
            string saveEquipment = "equipment";
            foreach (string item in _purchased)//exceeds: save purchased items
            {
                saveEquipment += $"|{item}";
            }
            outputFile.WriteLine(saveEquipment);
            
        }
    }

    public void LoadGoals()
    {
        string[] lines = System.IO.File.ReadAllLines($"{_userName}.txt"); //get everything written in target file, w/ each line as one string

        foreach (string line in lines)
        {
            string[] parts = line.Split("|"); //parse each line from source file into a collection of strings

            if (parts[0] == "simple") //call the 4-paramater constructor 
            {
                SimpleGoal simple = new SimpleGoal(parts[1], 
                parts[2], 
                int.Parse(parts[3]), 
                bool.Parse(parts[4]));

                _goals.Add(simple);
            }
            else if (parts[0] == "eternal") //call the constructor
            {
                EternalGoal eternal = new EternalGoal(parts[1], 
                parts[2], 
                int.Parse(parts[3]));

                _goals.Add(eternal);
            }
            else if (parts[0] == "checklist") //call the 5-parameter constructor
            {
                ChecklistGoal checklist = new ChecklistGoal(parts[1], 
                parts[2], 
                int.Parse(parts[3]), 
                int.Parse(parts[4]), 
                int.Parse(parts[5]));

                _goals.Add(checklist);
            }
            else if (parts[0] == "currency")//current tickets
            {
                _currency = int.Parse(parts[1]);
            }
            else if (parts[0] == "equipment") //purchased items
            {
                foreach (string item in parts)
                {
                    if (item != "equipment")
                    {
                        _purchased.Add(item);
                        _rewards.Remove(item);
                    }
                }
            }
        }
    }
}