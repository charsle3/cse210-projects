public class Activity
{
    protected string _name = "test name";
    protected string _description = "test description";
    protected int _duration = 0;
    public Activity() //no constructor for base model; all attributes are either hard coded per activity, or from user.
    {
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        
        Console.WriteLine($"Welcome to the {_name} activity!\n");
        Console.WriteLine(_description);
        Console.WriteLine("");
        Console.Write("For how long, in seconds, would you like to do this activity? "); //set duration attribute
        string duration = Console.ReadLine();

        _duration = int.Parse(duration);

        Console.Clear();

        Console.WriteLine("Get Ready. . .");

        ShowSpinner(5);

        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");

        Thread.Sleep(2000);

        Console.WriteLine($"You've completed {_duration} seconds of the {_name} activity!\n");

        Thread.Sleep(2000);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerAnimation = new List<string>();

        spinnerAnimation.Add(" | ");
        spinnerAnimation.Add(" / ");
        spinnerAnimation.Add(" - ");
        spinnerAnimation.Add(" \\ ");

        DateTime startSpin = DateTime.Now;
        DateTime endSpin = startSpin.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endSpin)
        {
            Console.Write(spinnerAnimation[i]);
            Thread.Sleep(300);

            Console.Write("\b\b\b \b");

            i++;

            if (i >= spinnerAnimation.Count) //loop back to the top
            {
                i = 0;
            }    
        }

        Console.Write("\b\b\b  \b");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}