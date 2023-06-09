using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Dtos;

public class NewReservationDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Table> Tables { get; set; }
    public DateTime ReservationStart { get; set; }
}
