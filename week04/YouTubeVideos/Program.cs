using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video apology = new Video("I'm So, So Sorry", "Markiplier", 5); //first video

        Comment first1 = new Comment("xXfunnyboneXx", "First!"); //comments for first video
        apology.NewComment(first1);
        Comment second1 = new Comment("Pukichu", "Fake! you can see the watermark.");
        apology.NewComment(second1);
        Comment third1 = new Comment("once-upon-a-nightmare", "Finally, this was overdue.");
        apology.NewComment(third1);
        Comment fourth1 = new Comment("who-cares", "What is this for? fr fr");
        apology.NewComment(fourth1);

        videos.Add(apology); //add first video to list

        Video puzzleGame = new Video("over the hump in less than 30 moves!", "RTGamer", 70); //second video

        Comment first2 = new Comment("xXfunnyboneXx", "First!"); //comments for second video
        puzzleGame.NewComment(first2);
        Comment second2 = new Comment("Glory Train", "I love this game!");
        puzzleGame.NewComment(second2);
        Comment third2 = new Comment("Sunset in Heaven", "I don't get it. Why is it blue?");
        puzzleGame.NewComment(third2);

        videos.Add(puzzleGame); //add second video to list

        Video expose = new Video("I Spent a Week Undercover in Dubai", "Max Fosh", 30); //third video

        Comment first3 = new Comment("xXfunnyboneXx", "First!"); //comments for third video
        expose.NewComment(first3);
        Comment second3 = new Comment("Jaki senao", "He really did that?");
        expose.NewComment(second3);
        Comment third3 = new Comment("youknowwho", "I've been there. this doesn't surprise me.");
        expose.NewComment(third3);
        Comment fourth3 = new Comment("PeriodMan", ".");
        expose.NewComment(fourth3);

        videos.Add(expose); //add third video to list

        string display = "";

        foreach (Video video in videos) //build display
        {
            display += $"{video.GetDisplay()}";
        }

        Console.WriteLine(display); //output display
    }
}