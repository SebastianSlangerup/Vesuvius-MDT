using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class Order
{
    public int OrderId { get; set; }
    
    public int OrderStatusId { get; set; }

    [JsonIgnore] public OrderStatus OrderStatus { get; set; } = null!;
    
    public int ServerId { get; set; }
    
    [JsonIgnore]
    public Employee Server { get; set; }
    
    public int? ReservationId { get; set; }
    
    [JsonIgnore]
    public Reservation? Reservation { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Tips { get; set; }

    [JsonIgnore]
    public List<OrderItem> OrderItems { get; set; }
}