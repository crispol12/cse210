using System;
using System.Threading;
using System.Collections.Generic;

public class VisualizationActivity : Activity
{
    private List<string> _scenes;
    private Random _rand;

    public VisualizationActivity()
        : base("Visualization Activity",
               "This activity will guide you to visualize a positive, peaceful scene. Close your eyes if you wish, and hold this image in your mind while you relax.")
    {
        _scenes = new List<string>() {
            "Imagine yourself sitting by a calm lake, the gentle water reflecting a clear blue sky.",
            "Visualize a green meadow with wildflowers, a light breeze, and the gentle warmth of the sun.",
            "Picture yourself on a quiet beach at sunset, listening to the waves and feeling the warm sand beneath your feet.",
            "Envision a serene forest, the sound of birds, the scent of pine, and the soft crunch of leaves underfoot."
        };
        _rand = new Random();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();

        Console.WriteLine();
        Console.WriteLine("Consider the following scene:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(GetRandomScene());
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Close your eyes (optional) and hold this image in your mind...");
        Console.Write("The visualization will begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        // Keep showing the spinner until the duration is over, simulating visualization time
        while (DateTime.Now < endTime)
        {
            ShowSpinner(1);
        }

        DisplayEndingMessage();
    }

    private string GetRandomScene()
    {
        int index = _rand.Next(_scenes.Count);
        return _scenes[index];
    }
}
