namespace Vesuvius_MDT.Models;

public class Order
{
    public int OrderId { get; set; }
    
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public int ServerId { get; set; }
    public Employee Server { get; set; }
    
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    
    public decimal Tips { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}