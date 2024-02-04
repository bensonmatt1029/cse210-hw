using System;
using System.Collections.Generic;
using System.IO;

// Journal class manages the entries and provides functionality to manipulate the journal
class Journal
{
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(string prompt, string response)
    {
        Entry newEntry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        Entries.Add(newEntry);
    }

    // Display all entries in the journal
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
                Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
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
                    if (parts.Length == 3)
                    {
                        AddEntry(parts[1], parts[2]);
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
}