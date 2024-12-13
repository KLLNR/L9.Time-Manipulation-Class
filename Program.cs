using System;

public class Time
{
    private int hours;
    private int minutes;
    private int seconds;

    public Time(int hours = 0, int minutes = 0, int seconds = 0)
    {
        SetTime(hours, minutes, seconds);
    }

    public void SetTime(int hours, int minutes, int seconds)
    {
        if (!IsValidHour(hours) || !IsValidMinuteOrSecond(minutes) || !IsValidMinuteOrSecond(seconds))
            throw new ArgumentException("Invalid time values provided.");

        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }

    public void SetHours(int hours)
    {
        if (!IsValidHour(hours))
            throw new ArgumentException("Invalid hour value.");
        this.hours = hours;
    }

    public void SetMinutes(int minutes)
    {
        if (!IsValidMinuteOrSecond(minutes))
            throw new ArgumentException("Invalid minute value.");
        this.minutes = minutes;
    }

    public void SetSeconds(int seconds)
    {
        if (!IsValidMinuteOrSecond(seconds))
            throw new ArgumentException("Invalid second value.");
        this.seconds = seconds;
    }
    
    public void AddTime(int addHours, int addMinutes, int addSeconds)
    {
        int totalSeconds = this.seconds + addSeconds;
        int totalMinutes = this.minutes + addMinutes + totalSeconds / 60;
        int totalHours = this.hours + addHours + totalMinutes / 60;

        this.seconds = totalSeconds % 60;
        this.minutes = totalMinutes % 60;
        this.hours = totalHours % 24; 
    }

    public override string ToString()
    {
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    private bool IsValidHour(int hour)
    {
        return hour >= 0 && hour < 24;
    }

    private bool IsValidMinuteOrSecond(int value)
    {
        return value >= 0 && value < 60;
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Time time = new Time(14, 30, 45);
            Console.WriteLine("Initial time: " + time);

            time.SetHours(16);
            time.SetMinutes(45);
            time.SetSeconds(50);
            Console.WriteLine("Updated time: " + time);

            time.AddTime(1, 20, 30);
            Console.WriteLine("After adding time: " + time);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

