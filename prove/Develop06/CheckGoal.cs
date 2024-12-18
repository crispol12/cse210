public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(GoalManager manager, int id, string name, string description, int points, int target, int bonus)
        : base(manager, id, name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            _manager.SetScore(_manager.GetScore() + _points);

            if (_amountCompleted == _target)
            {
                _manager.SetScore(_manager.GetScore() + _bonus);
            }
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkmark = IsComplete() ? "[X]" : "[ ]";
        return $"{checkmark} Checklist Goal: {_shortName} ({_description}) - Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|ID|Name|Desc|Points|AmountCompleted|Target|Bonus
        return $"ChecklistGoal|{_id}|{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
}
