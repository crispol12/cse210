public class EternalGoal : Goal
{
    public EternalGoal(GoalManager manager, int id, string name, string description, int points)
        : base(manager, id, name, description, points)
    {
    }

    public override void RecordEvent()
    {
        _manager.SetScore(_manager.GetScore() + _points);
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[∞] Eternal Goal: {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|ID|Name|Desc|Points
        return $"EternalGoal|{_id}|{_shortName}|{_description}|{_points}";
    }
}
