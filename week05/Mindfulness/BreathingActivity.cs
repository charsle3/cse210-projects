public class BreathingActivity : Activity
{
    public BreathingActivity() //hard coded name and description
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        base.DisplayStartingMessage(); //also sets duration

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); //calculate when to end

        while (DateTime.Now < endTime) //activity loop
        {
            Console.Write("\nBreath in. . . ");
            base.ShowCountDown(4);
            Console.Write("\nBreath out. . . ");
            base.ShowCountDown(6);

            Console.WriteLine();
        }

        Console.WriteLine();
        base.DisplayEndingMessage();
    }
}