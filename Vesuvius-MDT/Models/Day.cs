namespace Vesuvius_MDT.Models;

public class Day
{
    public List<Interval> Intervals { get; set; }
    public Day(DateTime date, int number_of_intevals, int inteval_len)
    {
        Date = date;
        Intervals = new List<Interval>();
        for (int i = 0; i < number_of_intevals; i++)
        {
            Intervals.Add(new Interval(Date, date + TimeSpan.FromHours(inteval_len))); 
        }
    }
    
    public DateTime Date { get; set; }
    
    
    
}

