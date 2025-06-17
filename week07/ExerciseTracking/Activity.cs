using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    
    protected double _distance;
    protected double _speed;
    protected double _pace;

    public Activity (DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance();  // using abstract because this is the parent class
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string date = _date.ToString("dd MMM yyyy");
        string activity = this.GetType().Name;   // "this" refers to the current object instance ---  Name gets the name of the class
        string minutes = _minutes.ToString();  //converting from int to string so that it can be written as a string
        string distance = GetDistance().ToString("0.00");
        string speed = GetSpeed().ToString("0.00");
        string pace = GetPace().ToString("0.00");
        
        return $" {date} {activity} ({minutes} min)- Distance {distance} miles, Speed {speed} mph, Pace: {pace} minutes per mile";
    }
}