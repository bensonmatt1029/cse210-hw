using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorization Program!");

        Console.WriteLine("Choose a scripture:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Proverbs 3:5-6");

        string userInput = Console.ReadLine();

        if (userInput == "1")
        {
            RunScripture("John 3:16",
                "For God so loved the world, that He gave His only Son, that whoever believes in Him should not perish but have eternal life.");
        }
        else if (userInput == "2")
        {
            RunScripture("Proverbs 3:5-6",
                "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to Him, and He will make your paths straight.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Program ending.");
        }
    }

    static void RunScripture(string reference, string text)
    {
        ScriptureManager scriptureManager = new ScriptureManager(reference, text);

        // Display the scripture initially
        scriptureManager.DisplayScripture();

        do
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
                break;

            if (userInput == "")
            {
                scriptureManager.HideRandomWords(3); // Adjust the count as needed
                scriptureManager.DisplayScripture();
            }
            else
            {
                Console.WriteLine("Invalid input. Please press Enter or type 'quit'.");
            }

        } while (!scriptureManager.AllWordsHidden);

        Console.WriteLine("All words in the scripture are now hidden. Program ending.");
    }
}