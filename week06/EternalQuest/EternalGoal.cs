public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int value) : base(name, description, value)
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        return _value;
    }

    public override string GetStringRepresentation()
    {
        return $"eternal|{_shortName}|{_description}|{_value}";
    }
}