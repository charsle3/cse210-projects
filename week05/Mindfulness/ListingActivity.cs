public class ListingActivity : Activity
{
    List<string> _prompts = new List<string>();
    List<string> _userList = new List<string>(); //Exceeds Expectations: remember user inputs and allow them to save externally if desired.
    public ListingActivity() //hard code in the prompts into the list
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts.Add("Who do you look up to?");
        _prompts.Add("What are you good at?");
        _prompts.Add("What good have you done this week?");
        _prompts.Add("What are your best jokes?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("When have people helped you?");
    }

    public void Run()
    {
        base.DisplayStartingMessage();

        Console.WriteLine("List as many examples as you can of the following prompt:");
        Console.WriteLine($"--------{GetRandomPrompt()}--------");
        Console.Write("Please begin in ");

        ShowCountDown(5);

        Console.WriteLine();

        _userList = GetListFromUser(); 

        Console.WriteLine($"You listed {_userList.Count} items!");
        Console.Write("Would you like to save your list? (y/n) "); // exceeds expectations: check to save user list
        string saveCheck = Console.ReadLine();

        if (saveCheck == "y")
        {
            SaveUserList();
        }

        Console.WriteLine();
        base.DisplayEndingMessage();
    }

    public string GetRandomPrompt() //no need for complicated logic here
    {
        Random random = new Random();
        int randomPrompt = random.Next(0, _prompts.Count);
        return _prompts[randomPrompt];
    }

    public List<string> GetListFromUser() //input loop -- only thing that uses _duration
    {
        List<string> userList = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            userList.Add(entry);
        }

        return userList;
    }

    public void SaveUserList() //exceeds expectations
    {
        using (StreamWriter outputFile = new StreamWriter("ListingActivityList.txt")) //save list
        {
            foreach (string entry in _userList)
            {
                outputFile.WriteLine(entry);
            }
        }
    }
}