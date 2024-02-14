using System;
using System.Collections.Generic;


class Scripture
{
    private string reference;
    private List<Verse> verses;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        InitializeVerses(text);
    }

    private void InitializeVerses(string text)
    {
        verses = new List<Verse>();

        string[] verseArray = text.Split(';');
        foreach (string verseText in verseArray)
        {
            verses.Add(new Verse(verseText.Trim()));
        }
    }

    public bool AllWordsHidden()
    {
        return verses.TrueForAll(v => v.AllWordsHidden());
    }

    public void HideRandomWords(int count)
    {
        foreach (Verse verse in verses)
        {
            verse.HideRandomWords(count);
        }
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"{reference}:");

        foreach (Verse verse in verses)
        {
            verse.DisplayVerse();
            Console.WriteLine(); // Add a newline after each verse
        }
    }
}
