using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string PhoneNumber { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; }
    
    [JsonIgnore]
    public List<Reservation> Reservations { get; set; }
    
    [JsonIgnore]
    public List<Order> Orders { get; set; }

}