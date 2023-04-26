using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class OrderStatus
{
    public int OrderStatusId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string Status { get; set; }
    
    public List<Order> Orders { get; set; }
}