using System;
using System.Collections.Generic;
using System.IO;

// Factory class to create goals
class GoalFactory
{
    public static Goal CreateGoal(string name, string type, int value = 0, int targetCount = 0)
    {
        switch (type.ToLower())
        {
            case "simple":
                return new SimpleGoal(name, value);
            case "eternal":
                return new EternalGoal(name, value);
            case "checklist":
                return new ChecklistGoal(name, value, targetCount);
            default:
                return null;
        }
    }
}