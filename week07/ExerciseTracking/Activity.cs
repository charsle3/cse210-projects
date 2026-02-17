public abstract class Activity
{
    protected string _name;
    protected string _date;
    protected int _length;
    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetSummary()
    {
        return $"{_date} {_name} ({_length}): Distance {GetDistance():0.00} miles, Speed {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
    
    public abstract double GetDistance();

    public abstract double GetSpeed();
    
    public abstract double GetPace();
}