using System;
using System.Collections.Generic;
using System.IO;

// Journal class manages the entries and provides functionality to manipulate the journal
class Journal
{

    public List<Entry> Entries { get; private set; } = new List<Entry>();

    public void AddEntry(string prompt, string response, Mood mood)
{
    Entry newEntry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), mood);
    Entries.Add(newEntry);
}

    public void DisplayEntries()
{
    Console.WriteLine("\n===== Journal Entries =====");

    if (Entries.Count == 0)
    {
        Console.WriteLine("No entries found.\n");
    }
    else
    {
        foreach (var entry in Entries)
        {
            string moodInfo = entry.EntryMood != null ? $"Mood: {entry.EntryMood.Emoji} {entry.EntryMood.MoodName}" : "Mood: Not specified";
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n{moodInfo}\n");
        }
    }

    Console.WriteLine("===========================\n");
}

    // Save the journal to a file
    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in Entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    // Load the journal from a file
    public void LoadFromFile(string fileName)
{
    Entries.Clear(); // Clear existing entries before loading new ones

    try
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|'); // Use "|" as the separator
                if (parts.Length == 4) // Check for four parts
                {
                    // Convert mood information back to Mood object
                    Mood mood = GetMoodFromInfo(parts[3]);

                    AddEntry(parts[1], parts[2], mood);
                }
            }
        }

        Console.WriteLine("Journal loaded successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading journal: {ex.Message}");
    }
}

private Mood GetMoodFromInfo(string moodInfo)
{
    if (moodInfo == "Not specified")
    {
        return null;
    }

    string[] moodParts = moodInfo.Split(' ');
    if (moodParts.Length == 2)
    {
        return new Mood(moodParts[1], moodParts[0]);
    }

    return null;
}
}