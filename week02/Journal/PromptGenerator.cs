public class PromptGenerator
{
    // list of prompts to pull from, one for each new entry
    public List<string> _prompts = new List<string> {"What blessings did you see today?", "What did you eat today?", "What's the funniest thing that happened today?", "What's the first thing you did today?", "Did you talk to anyone today?"};

    public PromptGenerator()
    {
    }

    //selects and returns one prompt randomly from above list
    public string GetRandomPrompt()
    {
        Random _random = new Random();
        int _randomPrompt = _random.Next(5);
        
        return _prompts[_randomPrompt];
    }
}