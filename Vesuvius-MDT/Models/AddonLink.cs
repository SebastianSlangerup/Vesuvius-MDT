namespace Vesuvius_MDT.Models;

public class AddonLink
{
    public int AddonLinksId { get; set; }

    public int? ItemGorupId { get; set; }
    public OrderItem? OrderItem { get; set; }

    public int AddonId { get; set; }
    public Addon Addon { get; set; }
}