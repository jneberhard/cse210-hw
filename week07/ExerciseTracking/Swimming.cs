using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()   // using override- because it will override the parent
    {
        return _laps * 50 / 1000.0 * .62;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / Minutes) * 60.00;
    }

    public override double GetPace()
    {
        double speed = GetSpeed();
        return 60.00 / speed;
    }
}