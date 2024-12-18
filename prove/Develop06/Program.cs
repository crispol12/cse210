using System;

/*Additional Creativity Feature 
A leveling system is added:
- Every time you earn points, you also earn the same amount of experience (XP).
- Every 1000 XP earned increases your level by one.
- The user's level and XP are displayed with the score, providing a sense of progression and motivation.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
