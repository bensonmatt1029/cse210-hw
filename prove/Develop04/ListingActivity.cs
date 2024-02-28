using System;
using System.Threading;


class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine(description);

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have 5 seconds to begin listing...");
        Thread.Sleep(5000); // Pause for 5 seconds

        Console.Write("Enter as many items as you can (press Enter after each item, type 'done' to finish): ");
        int itemCount = 0;
        string input;

        do
        {
            input = Console.ReadLine();
            itemCount++;
        } while (input.ToLower() != "done");

        Console.WriteLine($"You listed {itemCount - 1} items.");
    }
}