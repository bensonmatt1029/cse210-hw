using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class EternalQuestProgram
{
    private List<Goal> _goals;
    private int _score;

    public EternalQuestProgram()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal goal = _goals[goalIndex];
        goal.RecordEvent();
        _score += goal.Points;
        if (goal.Completed)
        {
            _score += goal.BonusPoints; // Apply bonus points if the goal is completed
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.Completed ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {status} {goal.Name} ({goal.GetType().Name})");
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"    Completed {checklistGoal.CompletedCount}/{checklistGoal.RequiredCount} times");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        string json = JsonSerializer.Serialize(_goals);
        File.WriteAllText(filename, json);
    }

    public void LoadGoals(string filename)
{
    try
    {
        string json = File.ReadAllText(filename);
        _goals = JsonSerializer.Deserialize<List<Goal>>(json);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
    }
}

public abstract class Goal
{
    public string Name { get; }
    public int Points { get; }
    public bool Completed { get; protected set; }
    public int BonusPoints { get; }

    public Goal(string name, int points, int bonusPoints)
    {
        Name = name;
        Points = points;
        BonusPoints = bonusPoints;
        Completed = false;
    }

    public abstract void RecordEvent();
}