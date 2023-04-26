namespace Vesuvius_MDT.Models;

public class Orders
{
    public int OrderId { get; set; }
    public int OrderStatusId { get; set; }
    public int CustomerId { get; set; }
    public int Server { get; set; }
    public int ReservationId { get; set; }
    public float Tips { get; set; }
}