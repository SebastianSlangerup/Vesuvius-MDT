namespace Vesuvius_MDT.Models;

public class Calender
{
    public List<Day> Days;

    public Calender(int intervals, int intervalLength)
    {
        Days = new List<Day>();
        for (int i = 0; i < DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month); i++)
        {
            Days.Add(new Day(DateTime.Now + TimeSpan.FromDays(i),intervals,intervalLength));
        }

      
    }
    
    public Dictionary<Day,List<Interval>> GetAvailableDays(List<Day> days)
    {
        Dictionary<Day, List<Interval>> availableDays = new Dictionary<Day, List<Interval>>();
        List<Interval> intervals = new List<Interval>();
        foreach (var day in days)
        {
            foreach (var interval in day.Intervals)
            {
                if (interval.ReservationId == null)
                {
                    interval.availabe = true;
                    intervals.Add(interval);
                    availableDays.Add(day, intervals);
                    continue;
                }
                interval.availabe = false;
            }
        }

        return availableDays;
    }
}