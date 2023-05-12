using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Controllers;

public class Test
{
    private List<Day> _days = new();

    public void Something()
    {
        
    }
}

public class Day
{
    public Day(DateTime date)
    {
        Date = date;
    }
    
    public DateTime Date { get; set; }
    public Interval? Interval { get; set; }
}

public class Interval
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime Slut { get; set; }
    public int ReservationId { get; set; }
}