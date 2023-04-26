namespace Vesuvius_MDT.Models;

public class OrderItem
{
    public int OrderItemId { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; } 
    
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }

    public int AddonLinkId { get; set; }
    public AddonLink AddonLink { get; set; }
    
    public int FoodStatusId { get; set; }
    public FoodStatus FoodStatus { get; set; }
    
    public int Count { get; set; }
    
    public decimal Paid { get; set; }
    
    public decimal Discount { get; set; }
}