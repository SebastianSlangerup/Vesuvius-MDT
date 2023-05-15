using System.Collections.ObjectModel;

namespace Vesuvius_MDT.Models;

public class Calender
{
    public List<Day> Days;

    public Calender(int intervals, int intervalLength, IEnumerable<Reservation> reservations)
    {
        Days = new List<Day>();
        for (int i = 0; i < DateTime.DaysInMonth(DateTime.Today.Year,DateTime.Today.Month); i++)
        {
            Days.Add(new Day(DateTime.Now + TimeSpan.FromDays(i),intervals,intervalLength,reservations));
        }
    }
    
    public dynamic GetAvailableDays(List<Day> _days)
    {

        List<Day> days = new List<Day>();
        List<Interval> intervals = new List<Interval>();

        var availableDays = new List<dynamic>(); 

        int i = 1;
        foreach (var day in Days)
        {
            foreach (var interval in day.Intervals)
            {
                availableDays.Add(day);
                availableDays.Add(interval);
                i++;
            }
        }

        return availableDays;
    }
}