using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
              "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        bool inhale = true;

        // Alternate between "Breathe in..." and "Breathe out..." until time is up
        while (DateTime.Now < endTime)
        {
            if (inhale)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(4); // inhale for a few seconds
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out...");
                ShowCountdown(4); // exhale for a few seconds
            }

            inhale = !inhale; // switch between inhale and exhale
        }

        DisplayEndingMessage();
    }
}
