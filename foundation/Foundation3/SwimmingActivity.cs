using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    // Distance (miles) = laps * 50 meters * (1 km / 1000 m) * 0.62 miles/km
    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed (mph) = distance / (time in hours)
        return GetDistance() / (LengthMinutes / 60.0);
    }

    public override double GetPace()
    {
        // Pace (min per mile) = total minutes / distance
        return LengthMinutes / GetDistance();
    }
}
