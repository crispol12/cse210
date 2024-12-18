using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create at least one instance of each activity
        Activity running = new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0); // 3 miles in 30 minutes
        Activity cycling = new CyclingActivity(new DateTime(2022, 11, 3), 45, 16.0); // 16 mph for 45 minutes
        Activity swimming = new SwimmingActivity(new DateTime(2022, 11, 3), 30, 30); // 30 laps

        // Put them in a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Call GetSummary for each and display the results
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
