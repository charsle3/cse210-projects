using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._jobTitle = "Senior Engineer";
        job1._company = "Microsoft";
        job1._startYear = 1995;
        job1._endYear = 2026;

        Job job2 = new Job();

        job2._jobTitle = "Junior Engineer";
        job2._company = "Apple";
        job2._startYear = 1980;
        job2._endYear = 1994;

        Resume resume1 = new Resume();

        resume1._fullName = "Harry Sheldon";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();
    }
}