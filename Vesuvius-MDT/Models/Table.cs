namespace Vesuvius_MDT.Models;

public class Table
{
    public int TableId { get; set; }

    public int TableSize { get; set; }

    public string Location { get; set; }

    public List<Reservation> Reservations { get; set; }
}