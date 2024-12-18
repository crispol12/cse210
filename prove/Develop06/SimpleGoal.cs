public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(GoalManager manager, int id, string name, string description, int points)
        : base(manager, id, name, description, points)
    {
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            _manager.SetScore(_manager.GetScore() + _points);
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string checkmark = _isComplete ? "[X]" : "[ ]";
        return $"{checkmark} Simple Goal: {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|ID|Name|Desc|Points|IsComplete
        return $"SimpleGoal|{_id}|{_shortName}|{_description}|{_points}|{_isComplete}";
    }

    public void SetCompletion(bool complete)
    {
        _isComplete = complete;
    }
}
