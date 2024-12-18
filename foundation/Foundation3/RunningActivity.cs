using System;

public class RunningActivity : Activity
{
    private double _distanceMiles;

    public RunningActivity(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    // Speed = distance / time (in hours)
    // time in hours = LengthMinutes / 60.0
    public override double GetSpeed()
    {
        return (GetDistance() / (LengthMinutes / 60.0));
    }

    // Pace = minutes / mile
    public override double GetPace()
    {
        return (double)LengthMinutes / GetDistance();
    }
}
