using System;
using System.Collections.Generic;


class ScriptureManager
{
    private Scripture scripture;

    public ScriptureManager(string reference, string text)
    {
        scripture = new Scripture(reference, text);
    }

    public bool AllWordsHidden => scripture.AllWordsHidden();

    public void HideRandomWords(int count)
    {
        scripture.HideRandomWords(count);
    }

    public void DisplayScripture()
    {
        scripture.DisplayScripture();
    }
}