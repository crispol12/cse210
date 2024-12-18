using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _xp = 0;
    private int _level = 1;
    private int _goalIdCounter = 0; // New counter for goal IDs

    public GoalManager() { }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. List Goals");
            Console.WriteLine("2. Show Goal Details");
            Console.WriteLine("3. Create a New Goal");
            Console.WriteLine("4. Record an Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListGoalNames();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    private void UpdateXPAndLevel(int pointsEarned)
    {
        _xp += pointsEarned;
        while (_xp >= 1000)
        {
            _xp -= 1000;
            _level++;
            Console.WriteLine("*** Congratulations! You've leveled up to level " + _level + " ***");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("\n---------------------------------");
        Console.WriteLine($"Score: {_score} | Level: {_level} | XP: {_xp}");
        Console.WriteLine("---------------------------------\n");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.\n");
            return;
        }

        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal g = _goals[i];
            // Now includes ID in details
            Console.WriteLine($"{i + 1}. {g.GetDetailsString()} (ID: {g.ID})");
        }
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.\n");
            return;
        }

        Console.Write("Enter the goal number to see details: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index -= 1;
            if (index >= 0 && index < _goals.Count)
            {
                Goal goal = _goals[index];
                Console.WriteLine($"\n{goal.GetDetailsString()}");
                Console.WriteLine($"ID: {goal.ID}\n");
            }
            else
            {
                Console.WriteLine("Invalid goal number.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.\n");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nCreate a new goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a type of goal: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points for achieving the goal or increment: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points. Aborting goal creation.\n");
            return;
        }

        _goalIdCounter++; // Increment ID for the new goal
        int newId = _goalIdCounter;
        Goal newGoal = null;

        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(this, newId, name, desc, points);
                break;
            case "2":
                newGoal = new EternalGoal(this, newId, name, desc, points);
                break;
            case "3":
                Console.Write("Enter the target count: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target count. Aborting.\n");
                    return;
                }
                Console.Write("Enter the bonus for completing the target: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus. Aborting.\n");
                    return;
                }
                newGoal = new ChecklistGoal(this, newId, name, desc, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.\n");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!\n");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.\n");
            return;
        }

        Console.Write("Enter the goal number to record an event: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index -= 1;
            if (index >= 0 && index < _goals.Count)
            {
                int oldScore = _score;
                _goals[index].RecordEvent();
                int pointsEarned = (_score - oldScore);
                if (pointsEarned > 0)
                {
                    UpdateXPAndLevel(pointsEarned);
                }
                Console.WriteLine("Event recorded successfully.\n");
            }
            else
            {
                Console.WriteLine("Invalid goal number.\n");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.\n");
        }
    }

    public void AddScore(int points)
    {
        _score += points;
    }

    public void SaveGoals()
    {
        Console.Write("Enter a filename to save (e.g. goals.txt): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"level:{_level}");
                writer.WriteLine($"experience:{_xp}");
                writer.WriteLine($"score:{_score}");

                foreach (Goal g in _goals)
                {
                    writer.WriteLine($"goal:{g.GetStringRepresentation()}");
                }
            }
            Console.WriteLine("Goals saved successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save goals: {ex.Message}\n");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter a filename to load (e.g. goals.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        try
        {
            _goals.Clear();
            List<string> loadedLines = new List<string>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    loadedLines.Add(line);

                    string[] parts = line.Split(new char[] { ':' }, 2);
                    if (parts.Length < 2) continue;

                    string label = parts[0];
                    string value = parts[1];

                    switch (label)
                    {
                        case "level":
                            if (int.TryParse(value, out int loadedLevel))
                                _level = loadedLevel;
                            break;

                        case "experience":
                            if (int.TryParse(value, out int loadedXp))
                                _xp = loadedXp;
                            break;

                        case "score":
                            if (int.TryParse(value, out int loadedScore))
                                _score = loadedScore;
                            break;

                        case "goal":
                            string[] goalParts = value.Split('|');
                            string type = goalParts[0];
                            switch (type)
                            {
                                case "SimpleGoal":
                                    {
                                        // Format: SimpleGoal|ID|Name|Desc|Points|IsComplete
                                        int loadedId = int.Parse(goalParts[1]);
                                        string sgName = goalParts[2];
                                        string sgDesc = goalParts[3];
                                        int sgPoints = int.Parse(goalParts[4]);
                                        bool sgComplete = bool.Parse(goalParts[5]);
                                        SimpleGoal sg = new SimpleGoal(this, loadedId, sgName, sgDesc, sgPoints);
                                        sg.SetCompletion(sgComplete);
                                        _goals.Add(sg);
                                        UpdateGoalIdCounter(loadedId);
                                        break;
                                    }
                                case "EternalGoal":
                                    {
                                        // EternalGoal|ID|Name|Desc|Points
                                        int loadedId = int.Parse(goalParts[1]);
                                        string egName = goalParts[2];
                                        string egDesc = goalParts[3];
                                        int egPoints = int.Parse(goalParts[4].TrimEnd(','));
                                        EternalGoal eg = new EternalGoal(this, loadedId, egName, egDesc, egPoints);
                                        _goals.Add(eg);
                                        UpdateGoalIdCounter(loadedId);
                                        break;
                                    }
                                case "ChecklistGoal":
                                    {
                                        // ChecklistGoal|ID|Name|Desc|Points|AmountCompleted|Target|Bonus
                                        int loadedId = int.Parse(goalParts[1]);
                                        string cgName = goalParts[2];
                                        string cgDesc = goalParts[3];
                                        int cgPoints = int.Parse(goalParts[4]);
                                        int cgAmount = int.Parse(goalParts[5]);
                                        int cgTarget = int.Parse(goalParts[6]);
                                        int cgBonus = int.Parse(goalParts[7]);
                                        ChecklistGoal cg = new ChecklistGoal(this, loadedId, cgName, cgDesc, cgPoints, cgTarget, cgBonus);
                                        cg.SetAmountCompleted(cgAmount);
                                        _goals.Add(cg);
                                        UpdateGoalIdCounter(loadedId);
                                        break;
                                    }
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.\n");

            Console.WriteLine("----- File Content Loaded -----");
            foreach (string fileLine in loadedLines)
            {
                Console.WriteLine(fileLine);
            }
            Console.WriteLine("--------------------------------\n");

            Console.WriteLine($"Current Level: {_level}");
            Console.WriteLine($"Current Experience: {_xp}");
            Console.WriteLine($"Current Score: {_score}\n");

            if (_goals.Count > 0)
            {
                Console.WriteLine("Loaded Goals:");
                foreach (Goal g in _goals)
                {
                    Console.WriteLine($"{g.GetDetailsString()} (ID: {g.ID})");
                    Console.WriteLine($"(Level: {_level}, Experience: {_xp}, Score: {_score})\n");
                }
            }
            else
            {
                Console.WriteLine("No goals were loaded.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load goals: {ex.Message}\n");
        }
    }

    private void UpdateGoalIdCounter(int loadedId)
    {
        // Ensure that the counter is at least as large as the highest loaded ID
        if (loadedId > _goalIdCounter)
        {
            _goalIdCounter = loadedId;
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }
}
