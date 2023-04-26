namespace Vesuvius_MDT.Models;

public class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int FoodCategoryId { get; set; }
    public FoodCategory FoodCategory { get; set; }

    public bool InStock { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}