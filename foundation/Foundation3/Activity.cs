using System;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthMinutes;

    public DateTime Date
    {
        get { return _date; }
        protected set { _date = value; }
    }

    public int LengthMinutes
    {
        get { return _lengthMinutes; }
        protected set { _lengthMinutes = value; }
    }

    protected Activity(DateTime date, int lengthMinutes)
    {
        Date = date;
        LengthMinutes = lengthMinutes;
    }

    // Virtual methods to be overridden by derived classes
    public virtual double GetDistance()
    {
        
        return 0;
    }

    public virtual double GetSpeed() 
    {
        // By default return 0. Derived classes override this.
        return 0;
    }

    public virtual double GetPace()
    {
        // By default return 0. Derived classes override this.
        return 0;
    }

    public virtual string GetSummary()
    {
        // Using short date string for formatting date
        // Distance in miles, Speed in mph, Pace in min/mile
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name.Replace("Activity", "")} ({LengthMinutes} min)- " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}
