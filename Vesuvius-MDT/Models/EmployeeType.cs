using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class EmployeeType
{
    public int EmployeeTypeId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string Type { get; set; }
    
    [JsonIgnore]
    public List<Employee>? Employees { get; set; }
}