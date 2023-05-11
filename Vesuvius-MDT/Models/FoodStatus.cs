using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class FoodStatus
{
    public int FoodStatusId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string Status { get; set; }

    [JsonIgnore]
    public List<OrderItem> OrderItems { get; set; }
}