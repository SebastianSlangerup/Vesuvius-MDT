using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class AddonLink
{
    public int AddonLinkId { get; set; }

    public int OrderItemId { get; set; }
    [JsonIgnore]
    public OrderItem OrderItem { get; set; }

    public int AddonId { get; set; }
    [JsonIgnore]
    public Addon Addon { get; set; }
}