using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration; // Duration in seconds

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int d) && d > 0)
            {
                _duration = d;
                break;
            }
            else
            {
                Console.Write("Please enter a valid positive number of seconds: ");
            }
        }
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDuration();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); // pause with spinner for a few seconds
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} for {GetDuration()} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        // Simple spinner animation for the given number of seconds
        char[] spinnerChars = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i % spinnerChars.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // remove the digit
        }
    }

    public abstract void Run();
}
