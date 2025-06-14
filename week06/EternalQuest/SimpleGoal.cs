using System;


public class SimpleGoal : Goal
{
    private bool _isComplete = false;
    
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    } 

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations!! You have earned {_points} points.");
            return _points;
        }
        else
        {
            Console.WriteLine("You have already done this goal.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}