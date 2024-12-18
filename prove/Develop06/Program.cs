using System;

/*
This program manages a set of goals and allows the user to:
- Create three types of goals:
  1) SimpleGoal: Marked complete once, earning points when completed.
  2) EternalGoal: Never completes, but every recorded event grants points.
  3) ChecklistGoal: Requires multiple completions. Each completion grants points, and upon reaching the target count, a bonus is awarded.

Basic functionality:
- Display goals with their status.
- Record events to earn points.
- Save and load goals, their status, and the user's score.
- Allow creating new goals of any type.

*** Additional Creativity Feature ***
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
