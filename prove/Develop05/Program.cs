using System;

class Program
{
    /*
     NOTE ON MEETING AND EXCEEDING REQUIREMENTS:
     - Abstraction: Each class has only relevant attributes and responsibilities.
     - Encapsulation: All member variables are private/protected, public methods are used for interaction.
     - Inheritance: Activity is the base class, and BreathingActivity, ReflectingActivity, ListingActivity, and VisualizationActivity inherit from it.
     - Inheriting Attributes and Behaviors: Common attributes (_name, _description, _duration) and methods (DisplayStartingMessage, DisplayEndingMessage, ShowSpinner, ShowCountdown) are in the base class Activity and used by derived classes.
     - Functionality:
       * Breathing Activity: Works as specified, alternating inhale/exhale with countdown until time is up.
       * Reflecting Activity: Shows a random prompt, then asks random reflection questions, pausing (spinner) between questions.
       * Listing Activity: Shows a prompt, counts down, then collects user-listed items until time ends, then displays the count.
       * Visualization Activity (extra): Added for creativity. Guides the user through a visualization exercise with a chosen duration and spinner animation.
     - Pausing/Animation: Spinner and countdowns are implemented using backspaces and Thread.Sleep for timing.
     - Style: Each class is in its own file, naming conventions and whitespace follow guidelines.
     - Creativity: The VisualizationActivity goes beyond the required activities.

     By adding the VisualizationActivity, we exceed the core requirements and demonstrate additional creativity.
     */

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Visualization Activity (Extra)");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");

            string choice = Console.ReadLine().Trim();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new VisualizationActivity();
                    break;
                case "5":
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }
}
