using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class Reservation
{
    public int ReservationId { get; set; }

    public List<Table> Tables { get; set; }

    public DateTime ReservationDateTime { get; set; }

    public DateTime ResevationStart { get; set; }

    public DateTime ResevationEnd { get; set; }

    [ForeignKey("Customer")]
    public int CustomerRefId { get; set; }
    public Customer Customer { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? Extra { get; set; }
}