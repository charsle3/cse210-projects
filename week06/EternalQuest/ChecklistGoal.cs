public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int value, int target) : base(name, description, value) // used for new goals
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = target * (value / 2); //differently from the class diagram / demo, I have the bonus as a function of how many times the goal needs to be done.
    }

    public ChecklistGoal(string name, string description, int value, int amountCompleted, int target) : base(name, description, value) //this constructor is used when loading existing goal from save file
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = target * (value / 2);
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        int points = _value;

        if (_amountCompleted == _target)
        {
            points += _bonus;
        }

        return points;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetails()
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

        details += $"{_shortName} -- {_description} -- Current progress: {_amountCompleted}/{_target}\nValue: {_value} Tickets\nCompletion Bonus: {_bonus} tickets";

        return details;
    }

    public override string GetStringRepresentation()
    {
        return $"checklist|{_shortName}|{_description}|{_value}|{_amountCompleted}|{_target}";
    }
}