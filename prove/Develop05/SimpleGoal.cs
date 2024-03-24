using System;
using System.Collections.Generic;
using System.IO;

<<<<<<< HEAD

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, int bonusPoints) : base(name, points, bonusPoints) { }

    public override void RecordEvent()
    {
        Completed = true;
=======
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
>>>>>>> c2536e49ad05e89834e7c75392637944f3c88743
    }
}
