public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name, string description, int value) : base(name, description, value) //used for new goals
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int value, bool isComplete) : base(name, description, value) //this constructor used when loading existing goal from save file
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;

        return _value;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"simple|{_shortName}|{_description}|{_value}|{_isComplete}"; 
    }
}