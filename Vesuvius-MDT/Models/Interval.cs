namespace Vesuvius_MDT.Models;
public class Interval
{
    public Interval(DateTime start, DateTime end)
    {
        this.Start = start;
        this.end = end;
        this.availabe = false;

    }
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime end { get; set; }
    public int ReservationId { get; set; }
    public bool availabe { get; set; }
}