using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public Mood EntryMood { get; set; }

    public Entry(string prompt, string response, string date, Mood mood)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        EntryMood = mood;
    }

    public override string ToString()
    {
        string moodInfo = EntryMood != null ? $"{EntryMood.Emoji} {EntryMood.MoodName}" : "Not specified";
        return $"{Date}|{Prompt}|{Response}|{moodInfo}";
    }
}