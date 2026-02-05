public class Assignment
{
    private string _studentName = "";
    private string _topic = "";

    public Assignment(string studentName, string topic)
    {
        _topic = topic;
        _studentName = studentName;
    }

    public string GetSummary()
    {
        return $"Student {_studentName}, for the {_topic} class.";
    }

    public string GetName()
    {
        return _studentName;
    }
}