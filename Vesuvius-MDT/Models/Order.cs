namespace Vesuvius_MDT.Models;

public class Order
{
    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }
    public int CustomerId { get; set; }
    public int Server { get; set; }
    public int ReservationId { get; set; }
    public float Tips { get; set; }

    public List<Reservation> Reservations { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}