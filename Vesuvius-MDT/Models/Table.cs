namespace Vesuvius_MDT.Models;

public class Table
{
    public int Id { get; set; }

    public int Size { get; set; }

    public string Location { get; set; }

    public List<Reservation> Reservations { get; set; }
}