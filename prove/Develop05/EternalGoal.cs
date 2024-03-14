using System;
using System.Collections.Generic;
using System.IO;

// Define an eternal goal
class EternalGoal : Goal
{
    public int Value { get; }

    public EternalGoal(string name, int value) : base(name)
    {
        Value = value;
    }

    public override int RecordEvent()
    {
        // Record progress for eternal goal and return points
        Console.WriteLine($"Progress recorded for eternal goal '{Name}'. You gained {Value} points.");
        return Value;
    }

    public override string DisplayStatus()
    {
        return $"[ ] {Name}";
    }

    public override string Serialize()
    {
        return $"Eternal,{Name},{Value}";
    }
}
