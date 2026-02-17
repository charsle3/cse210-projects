using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        RunningActivity running = new RunningActivity("17 Feb 2026", 30, 3.2);
        activities.Add(running);

        BikingActivity biking = new BikingActivity("17 Feb 2026", 30, 25.1);
        activities.Add (biking);

        SwimmingActivity swimming = new SwimmingActivity("17 Feb 2026", 22, 20);
        activities.Add (swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}