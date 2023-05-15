namespace Vesuvius_MDT.Models;

public class Day
{
    public List<Interval> Intervals { get; set; }
    public Day(DateTime date, int number_of_intevals, int inteval_len, IEnumerable<Reservation> reservations)
    {
        Date = date;
        Intervals = new List<Interval>();
        for (int i = 0; i < number_of_intevals; i++)
        {
            var enumerable = reservations.ToList();
            if (i == 1)
            {
                Intervals.Add(new Interval(Date.AddHours(inteval_len + inteval_len), date.AddHours(inteval_len + inteval_len),enumerable));
            }
            
            if (i >= 1)
            {
                Intervals.Add(new Interval(Date.AddHours(inteval_len * i), date.AddHours(inteval_len * i),enumerable));
            }
            Intervals.Add(new Interval(Date, date.AddHours(inteval_len),enumerable));
        }
    }
    
    public DateTime Date { get; set; }
}

