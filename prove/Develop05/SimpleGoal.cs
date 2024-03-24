using System;
using System.Collections.Generic;
using System.IO;


public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, int bonusPoints) : base(name, points, bonusPoints) { }

    public override void RecordEvent()
    {
        Completed = true;
    }
}
