public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)  //this is the constructor
    {
        _studentName = studentName;
        _topic = topic;
    }


    public string GetStudentName()  // method
    {
        return _studentName;
    }

    public string GetTopic()   //method
    {
        return _topic;
    }

    public string GetSummary()   // menthod
    {
        return _studentName + " - " + _topic;
    }
}