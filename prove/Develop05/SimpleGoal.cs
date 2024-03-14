using System;
using System.Collections.Generic;
using System.IO;

// Define a simple goal
class SimpleGoal : Goal
{
    public int Value { get; }

    public SimpleGoal(string name, int value) : base(name)
    {
        Value = value;
    }

    public override int RecordEvent()
    {
        // Mark simple goal as complete and return points
        Console.WriteLine($"Goal '{Name}' completed. You gained {Value} points.");
        return Value;
    }

    public override string DisplayStatus()
    {
        return $"[ ] {Name}";
    }

    public override string Serialize()
    {
        return $"Simple,{Name},{Value}";
    }
}
