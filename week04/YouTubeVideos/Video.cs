
public class Video

{
    private string _title;   // data that describes the video- it is private - can't be modified outside the class
    private string _author;
    private int _lengthSeconds;

    public string Title  // Property that allows sage access to private fields
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }
    public int LengthSeconds
    {
        get { return _lengthSeconds; }
        set { _lengthSeconds = value; }


    }
    
    private List<Comment> comments = new List<Comment>();  // creates an empty list - to store comment objects.

    public Video(string title, string author, int lengthSeconds) // Constructor - when new video is there it has the 3 fields
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment) // allows comments to be added to the video
    {
        comments.Add(comment);
    }

    public int GetCommentCount()   // this method tells how many comments on the video
    {
        return comments.Count;
    }

    public List<Comment> GetAllComments()  // method lists the comments 
    {
        return comments;
    }
}

