using System;
using System.Collections.Generic;
using System.IO;

// Define the base class for goals
abstract class Goal
{
    public string Name { get; set; }

    public Goal(string name)
    {
        Name = name;
    }

    // Record an event and return the points earned
    public abstract int RecordEvent();

    // Display the status of the goal
    public abstract string DisplayStatus();

    // Serialize the goal object into a string
    public abstract string Serialize();
}
