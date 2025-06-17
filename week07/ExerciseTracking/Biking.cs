using System;

public class Biking : Activity
{
    public Biking(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()  // using override- because it will override the parent
    {
        return _speed * (Minutes /60.00);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60.00 / _speed;
    }
}