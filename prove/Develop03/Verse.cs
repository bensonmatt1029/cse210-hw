using System;
using System.Collections.Generic;


class Verse
{
    private List<Word> words;
    private HashSet<int> hiddenIndices = new HashSet<int>();

    public string Text { get; private set; }

    public Verse(string text)
    {
        Text = text;
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public bool AllWordsHidden()
    {
        return words.TrueForAll(w => w.IsHidden);
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            // Find an index of an unhidden word that hasn't been hidden before
            int index;
            do
            {
                index = random.Next(words.Count);
            } while (words[index].IsHidden || hiddenIndices.Contains(index));

            words[index].Hide();
            hiddenIndices.Add(index);
        }
    }

    public void DisplayVerse()
    {
        foreach (Word word in words)
        {
            Console.Write(word.IsHidden ? "________ " : $"{word.Text} ");
        }
    }
}