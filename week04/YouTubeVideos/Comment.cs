
public class Comment
{
    private string _name;   // private fields to store the actual data
    private string _commentText;

    public string Name   //property called Name -- get returns the private name -- set allows external code to change the _name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string CommentText
    {
        get { return _commentText; }
        set { _commentText = value; }
    }

    public Comment(string name, string commentText)  // constructor or method - takesname and CommentText and sets those to private
    {
        _name = name;
        _commentText = commentText;
    }
}