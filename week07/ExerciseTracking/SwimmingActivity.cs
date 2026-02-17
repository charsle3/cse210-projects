public class SwimmingActivity : Activity
{
    private int _lapsCount;

    public SwimmingActivity(string date, int length, int lapsCount) : base(date, length)
    {
        _name = "Swimming";
        _lapsCount = lapsCount;
    }

    public override double GetDistance()
    {
        return _lapsCount * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / _length;
    }

    public override double GetPace()
    {
        return _length / GetDistance();
    }
}