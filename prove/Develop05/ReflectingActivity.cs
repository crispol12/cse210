using System;
using System.Threading;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _rand;

    public ReflectingActivity()
        : base("Reflecting Activity",
               "This activity will help you reflect on times in your life when you showed strength and resilience. It will help you recognize your power and how you can use it in other areas of your life.")
    {
        _prompts = new List<string>() {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>() {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _rand = new Random();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("---------------------------------");
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now, reflect on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(8); // pause for user to think
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        int index = _rand.Next(_questions.Count);
        return _questions[index];
    }
}
