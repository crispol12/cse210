using System;

class Program
{
    /*
    REQUIREMENTS AND EXTRA CREATIVITY:

    - Abstraction: Each class includes only the attributes and methods it needs.
    - Encapsulation: All member variables are private or protected, and we use public methods to interact with them.
    - Inheritance: "Activity" is the base class. "BreathingActivity", "ReflectingActivity", "ListingActivity", and "VisualizationActivity" all inherit from it.
    - Inheriting Attributes and Behaviors: Common attributes (_name, _description, _duration) and methods (DisplayStartingMessage, DisplayEndingMessage, ShowSpinner, ShowCountdown) are defined in the "Activity" base class. The other classes use these shared attributes and methods.
    
    - Functionality:
      * Breathing Activity: Asks the user to breathe in and out with a countdown until the time runs out.
      * Reflecting Activity: Shows a random prompt, then asks random reflection questions. The user thinks about the questions while a spinner animation plays.
      * Listing Activity: Shows a prompt and gives the user time to list as many items as possible before time runs out. Then it displays how many items the user listed.
      * Visualization Activity (extra): This is an added activity to show creativity. It guides the user to imagine a peaceful scene for the chosen duration, showing a spinner during that time.
    
    - Pausing/Animation: We use a spinner animation and countdown timers. These use backspaces and Thread.Sleep to create the effect.
    - Style: Each class is in its own file. We follow consistent naming conventions and proper whitespace.
    - Creativity: By adding the VisualizationActivity, we go beyond the basic requirements.

    With the VisualizationActivity, this program not only meets the basic requirements but also shows extra creativity.
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
