using System;

public class CyclingActivity : Activity
{
    private double _speedMph; // Speed in miles per hour

    public CyclingActivity(DateTime date, int lengthMinutes, double speedMph)
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    // Distance = speed * time (in hours)
    public override double GetDistance()
    {
        return _speedMph * (LengthMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    // Pace = minutes per mile = total minutes / distance
    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }
}
