namespace Vesuvius_MDT.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int MenuItemId { get; set; }
    public int FoodStatusId { get; set; }
    public int Count { get; set; }
    public decimal Paid { get; set; }
    public decimal Tips { get; set; }
}