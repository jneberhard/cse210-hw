using System;

public class Running : Activity
{
    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()   // using override- because it will override the parent
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Minutes) * 60.0;
    }

    public override double GetPace()
    {
        return (Minutes / _distance);
    }

}