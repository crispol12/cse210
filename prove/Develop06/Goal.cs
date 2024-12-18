public abstract class Goal
{
    protected int _id;
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected GoalManager _manager; 

    public int ID => _id;

    public Goal(GoalManager manager, int id, string name, string description, int points)
    {
        _manager = manager;
        _id = id;
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
