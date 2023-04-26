namespace Vesuvius_MDT.Models;

public class Reservation
{
    public int ReservationId { get; set; }

    public int TableId { get; set; }
    public Table Table { get; set; }

    public DateTime ReservationDateTime { get; set; }

    public DateTime ResevationStart { get; set; }

    public DateTime ResevationEnd { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public string Extra { get; set; }
}