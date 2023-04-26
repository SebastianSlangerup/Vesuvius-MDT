namespace Vesuvius_MDT.Models;

public class Addon
{
    public int AddonId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public List<AddonLink> AddonLinks { get; set; }
}