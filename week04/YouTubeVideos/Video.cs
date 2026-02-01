using System.Transactions;

public class Video
{
    string _title = "";
    string _author = "";
    int _length = 0;
    List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public void NewComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public string GetDisplay()
    {
        string display;

        display = $"++++++++++++++++++++++++++++\nTitle: {_title}({_length}min)\nBy: {_author}\n{GetNumComments()} comments\n\n";

        foreach (Comment comment in _comments)
        {
            display += comment.GetDisplay();
        }

        display += "\n";

        return display;
    }
}