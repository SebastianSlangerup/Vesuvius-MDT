namespace Vesuvius_MDT.Models;

public class FoodStatus
{
    public int FoodStatusId { get; set; }
    public string Status { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}