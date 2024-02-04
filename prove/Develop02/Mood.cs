using System;
using System.Collections.Generic;
using System.IO;


class Mood
{
    public string MoodName { get; set; }
    public string Emoji { get; set; }

    public Mood(string moodName, string emoji)
    {
        MoodName = moodName;
        Emoji = emoji;
    }
}