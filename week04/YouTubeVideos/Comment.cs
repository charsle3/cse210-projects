public class Comment
{
    private string _name = "";
    private string _content = "";

    public Comment(string name, string text)
    {
        _name = name;
        _content = text;
    }

    public string GetDisplay() //format username and comment content together
    {
        return $"User '{_name}'\n\"{_content}\"\n";
    }
}