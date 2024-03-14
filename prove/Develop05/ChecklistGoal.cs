using System;
using System.Collections.Generic;
using System.IO;

// Define a checklist goal
class ChecklistGoal : Goal
{
    public int Value { get; }
    public int TargetCount { get; }
    public int CompletedCount { get; set; }

    public ChecklistGoal(string name, int value, int targetCount) : base(name)
    {
        Value = value;
        TargetCount = targetCount;
        CompletedCount = 0;
    }

    public override int RecordEvent()
    {
        // Increment completed count and return points
        CompletedCount++;
        Console.WriteLine($"Goal '{Name}' completed ({CompletedCount}/{TargetCount}). You gained {Value} points.");
        if (CompletedCount == TargetCount)
        {
            Console.WriteLine($"Congratulations! You completed '{Name}' and earned a bonus of {Value} points.");
            return Value * 2; // Bonus points
        }
        return Value;
    }

    public override string DisplayStatus()
    {
        return $"[ ] {Name} ({CompletedCount}/{TargetCount})";
    }

    public override string Serialize()
    {
        return $"Checklist,{Name},{Value},{TargetCount},{CompletedCount}";
    }
}