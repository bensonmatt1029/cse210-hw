using System;
using System.Collections.Generic;
using System.IO;


// UserInterface class handles user interactions and menu
class UserInterface
{
    private Journal journal = new Journal();

    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            string choice = GetUserInput("Select an option: ");

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;

                case "2":
                    DisplayJournal();
                    break;

                case "3":
                    SaveJournalToFile();
                    break;

                case "4":
                    LoadJournalFromFile();
                    break;

                case "5":
                    Exit();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.\n");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
    }

    private void WriteNewEntry()
    {
        Console.WriteLine("Writing a new entry...");
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        string response = GetUserInput("Response: ");

        // Mood tracking
        Mood selectedMood = GetSelectedMood();
        journal.AddEntry(randomPrompt, response, selectedMood);

        Console.WriteLine("Entry saved successfully!");
    }

    private Mood GetSelectedMood()
    {
        Console.WriteLine("Select your mood:");

        // Assume you have a list of predefined moods
        List<Mood> predefinedMoods = GetPredefinedMoods();

        for (int i = 0; i < predefinedMoods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {predefinedMoods[i].Emoji} {predefinedMoods[i].MoodName}");
        }

        int selectedMoodIndex = GetNumericInput("Enter the number corresponding to your mood: ", predefinedMoods.Count) - 1;
        return predefinedMoods[selectedMoodIndex];
    }

    private int GetNumericInput(string prompt, int maxValue)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (int.TryParse(input, out int result) && result >= 1 && result <= maxValue)
        {
            return result;
        }

        Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxValue}.\n");
    }
}

private List<Mood> GetPredefinedMoods()
{
    // Define a list of predefined moods with corresponding emojis
    return new List<Mood>
    {
        new Mood("Happy", "😄"),
        new Mood("Sad", "😢"),
        new Mood("Excited", "🎉"),
        new Mood("Calm", "😌"),
        // Add more moods as needed
    };
}

    private void DisplayJournal()
    {
        journal.DisplayEntries();
    }

    private void SaveJournalToFile()
    {
        string saveFileName = GetUserInput("Enter a filename to save the journal: ");
        journal.SaveToFile(saveFileName);
    }

    private void LoadJournalFromFile()
    {
        string loadFileName = GetUserInput("Enter a filename to load the journal: ");
        journal.LoadFromFile(loadFileName);
    }

    private void Exit()
    {
        Console.WriteLine("Exiting the program. Goodbye!");
        Environment.Exit(0);
    }

    private string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    // A method to generate a random prompt from a list
    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // Add your own prompts here
        };

        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
