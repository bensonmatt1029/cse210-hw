using System;
using System.Collections.Generic;
using System.IO;


public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, int bonusPoints) : base(name, points, bonusPoints) { }

    public override void RecordEvent()
    {
        // Eternal goal does not need to be marked as completed
    }
}