public class Comment
{
    string _name = "";
    string _content = "";

    public Comment(string name, string text)
    {
        _name = name;
        _content = text;
    }

    public string GetDisplay()
    {
        return $"User '{_name}'\n\"{_content}\"\n";
    }
}