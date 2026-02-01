using System.Transactions;

public class Video
{
    private string _title = "";
    private string _author = "";
    private int _length = 0;
    List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetNumComments() //number of comments
    {
        return _comments.Count;
    }

    public void NewComment(Comment comment) //used to add comments to a video
    {
        _comments.Add(comment);
    }

    public string GetDisplay() //format video details and comments together
    {
        string display;

        display = $"++++++++++++++++++++++++++++\nTitle: {_title}({_length}min)\nBy: {_author}\n{GetNumComments()} comments\n\n"; //video details

        foreach (Comment comment in _comments) //stack comments on
        {
            display += comment.GetDisplay();
        }

        display += "\n";

        return display; 
    }
}