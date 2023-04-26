namespace Vesuvius_MDT.Models;

public class AddonLink
{
    public int Id { get; set; }

    public int? OrderItemId { get; set; }
    public OrderItem? OrderItem { get; set; }

    public int AddonId { get; set; }
    public Addon Addon { get; set; }
}