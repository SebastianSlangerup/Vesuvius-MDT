using System.Collections.ObjectModel;

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
    
    public List<Dictionary<Dictionary<int, Day>, List<Interval>>> GetAvailableDays(List<Day> _days)
    {

        List<Day> days = new List<Day>();
        List<Interval> intervals = new List<Interval>();

        int i = 1;
        foreach (var day in days)
        {
            foreach (var interval in day.Intervals)
            {
                if (interval.ReservationId == 0 || interval.ReservationId == null)
                {
                    interval.availabe = true;
                    intervals.Add(interval);

                    availableDays.Add(dict);
                    Console.WriteLine("+1");
                }
                else
                {
                    
                    interval.availabe = false;
                    Console.WriteLine("-1");
                    Console.WriteLine(interval.ReservationId);
                }

                i++;
            }
        }

        return availableDays;
    }
}