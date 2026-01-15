public class Resume
{
    public string _fullName = "";
    public List<Job> _jobs = new List<Job>();

    public Resume()
    {
    }

    public void Display()
    {
        Console.WriteLine($"Resume for {_fullName}!");

        foreach(Job j in _jobs)
        {
            j.Display();
        }
    }
}