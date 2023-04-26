namespace Vesuvius_MDT.Models;

public class OrderStatus
{
    public int OrderStatusId { get; set; }
    
    public string Status { get; set; }
    
    public List<Order> Orders { get; set; }
}