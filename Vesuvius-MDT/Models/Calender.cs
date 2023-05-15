using Vesuvius_MDT.Controllers;

namespace Vesuvius_MDT.Models;

public class Calender
{
    public List<Day> Days;

    public Calender(int intervals,int inteval_len)
    {
        Days = new List<Day>();
        for (int i = 0; i < DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month); i++)
        {
            Days.Add(new Day(DateTime.Now + TimeSpan.FromDays(i),intervals,inteval_len));
        }

      
    }
    
    public Dictionary<Day,List<Interval>> get_available(List<Day> _days)
    {
        Dictionary<Day, List<Interval>> avaviable_days = new Dictionary<Day, List<Interval>>();
        List<Interval> Intervals = new List<Interval>();
        foreach (var day in _days)
        {
            foreach (var interval in day.Intervals)
            {
                if (interval.ReservationId == null)
                {
                    interval.availabe = true;
                    Intervals.Add(interval);
                    avaviable_days.Add(day, Intervals);
                    continue;
                }
                interval.availabe = false;

                continue;
            }
        }

        return avaviable_days;
    }
}