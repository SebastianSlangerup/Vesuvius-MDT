using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Dtos;

public class NewOrderReservationDto
{
    public int ReservationId { get; set; }
    public Dictionary<OrderItem, List<Addon>?> OrderItems { get; set; }
    public int EmployeeId { get; set; }
}