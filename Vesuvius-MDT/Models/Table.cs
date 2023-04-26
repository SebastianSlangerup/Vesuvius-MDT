using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class Table
{
    public int TableId { get; set; }

    public int TableSize { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Location { get; set; }

    public List<Reservation> Reservations { get; set; }
}