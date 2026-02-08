public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    List<int> _askedQuestions = new List<int>(); //exceeds expectations
    public ReflectingActivity() //hard code prompts and questions
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run() //no need for one line display functions as indicated in provided class diagram
    {
        base.DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt: \n");
        Console.WriteLine($"--{GetRandomPrompt()}--\n");
        Console.WriteLine("When you have something in mind, please press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each question as they relate to this experience.");
        Console.Write("You may begin in: ");
        
        ShowCountDown(5);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime) //question loop
        {
            Console.Write($"> {GetRandomQuestion()} ");
            base.ShowSpinner(5);
            Console.WriteLine();
        }
        
        Console.WriteLine();

        base.DisplayEndingMessage();
    }

    public string GetRandomPrompt() //no need for complicated logic
    {
        Random random = new Random();
        int randomPrompt = random.Next(0, _prompts.Count);
        return _prompts[randomPrompt];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomQuestion = 99; //do-while loops don't like uninitialized values. Set it to something ridiculous

        do //Exceeds expectations; don't ask an already asked question
        {
            randomQuestion = random.Next(0, _questions.Count); //random number

            if (_askedQuestions.Count == _questions.Count) //if we've asked all the questions, clear the asked ones
            {
                _askedQuestions.Clear();
            }

        } while(_askedQuestions.Contains(randomQuestion)); //repeat if the selected question has been asked

        _askedQuestions.Add(randomQuestion); //record the asking
        
        return _questions[randomQuestion]; //ask
    }
}