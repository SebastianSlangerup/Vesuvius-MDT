namespace Vesuvius_MDT.Models;

public class FoodCategory
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<MenuItem> MenuItems { get; set; }
}