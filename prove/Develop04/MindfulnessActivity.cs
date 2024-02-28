using System;
using System.Threading;


class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public virtual void Start()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.Write("Enter the duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public virtual void PerformActivity()
    {
        // Placeholder method, to be overridden by specific activities
    }

    public virtual void End()
    {
        Console.WriteLine($"Good job! You have completed the {name} activity for {duration} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}