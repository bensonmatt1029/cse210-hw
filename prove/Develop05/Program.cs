using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    private List<Goal> goals;
    private int score;

    public Program()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                score += goal.RecordEvent();
                break;
            }
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }

    public void SaveProgress(string filename)
    {
        using (StreamWriter file = File.CreateText(filename))
        {
            foreach (var goal in goals)
            {
                file.WriteLine(goal.Serialize());
            }
            file.WriteLine(score);
        }
    }

    public void LoadProgress(string filename)
    {
        using (StreamReader file = File.OpenText(filename))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (int.TryParse(line, out int parsedScore))
                {
                    score = parsedScore;
                    break;
                }
                else
                {
                    goals.Add(CreateGoalFromString(line));
                }
            }
        }
    }

    // Create a goal object from a string representation
    private Goal CreateGoalFromString(string data)
    {
        string[] parts = data.Split(',');
        string type = parts[0];
        string name = parts[1];
        int value = int.Parse(parts[2]);
        if (type == "Checklist")
        {
            int targetCount = int.Parse(parts[3]);
            int completedCount = int.Parse(parts[4]);
            var goal = GoalFactory.CreateGoal(name, type, value, targetCount) as ChecklistGoal;
            goal.CompletedCount = completedCount;
            return goal;
        }
        else
        {
            return GoalFactory.CreateGoal(name, type, value);
        }
    }

    static void Main(string[] args)
    {
        Program program = new Program();
        // Load progress if available
        if (File.Exists("progress.txt"))
        {
            program.LoadProgress("progress.txt");
        }

        // Interactive menu
        while (true)
        {
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Load Progress");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Add Goal
                    Console.WriteLine("Enter goal details:");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Type (Simple, Eternal, Checklist): ");
                    string type = Console.ReadLine();
                    Goal goal = GoalFactory.CreateGoal(name, type);
                    if (goal != null)
                    {
                        program.AddGoal(goal);
                        Console.WriteLine("Goal added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                    }
                    break;
                case 2:
                    // Record Event
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    program.RecordEvent(goalName);
                    Console.WriteLine("Event recorded.");
                    break;
                case 3:
                    // Display Goals
                    Console.WriteLine("Goals:");
                    program.DisplayGoals();
                    break;
                case 4:
                    // Display Score
                    program.DisplayScore();
                    break;
                case 5:
                    // Save Progress
                    program.SaveProgress("progress.txt");
                    Console.WriteLine("Progress saved.");
                    break;
                case 6:
                    // Load Progress
                    program.LoadProgress("progress.txt");
                    Console.WriteLine("Progress loaded.");
                    break;
                case 7:
                    // Exit
                    program.SaveProgress("progress.txt");
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

}