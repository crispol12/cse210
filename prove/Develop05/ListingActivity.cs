using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private Random _rand;

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many as you can in a certain area.")
    {
        _prompts = new List<string>() {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who have you helped this week?",
            "When have you felt the Holy Spirit this month?",
            "Who are some of your personal heroes?"
        };
        _rand = new Random();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("---------------------------------");
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine("---------------------------------");
        Console.Write("You may begin listing in: ");
        ShowCountdown(5);
        Console.WriteLine();
        
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new List<string>();

        Console.WriteLine("Start listing items now (press Enter after each item): ");
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string entry = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(entry))
                    items.Add(entry);
            }
            else
            {
                Thread.Sleep(100);
            }
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
