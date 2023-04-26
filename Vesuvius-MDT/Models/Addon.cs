using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class Addon
{
    public int AddonId { get; set; }

    public string Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public List<AddonLink> AddonLinks { get; set; }
}