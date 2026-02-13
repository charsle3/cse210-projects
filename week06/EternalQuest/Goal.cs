public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _value;

    public Goal(string name, string description, int value)
    {
        _shortName = name;
        _description = description;
        _value = value;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetails()
    {
        string details = "";

        if (IsComplete())
        {
            details += "[X] ";
        }
        else
        {
            details += "[ ] ";
        }

        details += $"{_shortName} -- {_description}\nValue: {_value} Tickets";

        return details;
    }

    public abstract string GetStringRepresentation();
}