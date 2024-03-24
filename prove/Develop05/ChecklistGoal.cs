using System;
using System.Collections.Generic;
using System.IO;


public class ChecklistGoal : Goal
{
    public int RequiredCount { get; }
    public int CompletedCount { get; private set; }

    public ChecklistGoal(string name, int points, int bonusPoints, int requiredCount) : base(name, points, bonusPoints)
    {
        RequiredCount = requiredCount;
        CompletedCount = 0;
    }

    public override void RecordEvent()
    {
        CompletedCount++;
        if (CompletedCount >= RequiredCount)
        {
            Completed = true;
        }
    }
}