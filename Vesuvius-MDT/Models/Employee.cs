using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vesuvius_MDT.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string EmployeeName { get; set; }
    
    public int? EmployeeTypeId { get; set; }
    [JsonIgnore]
    public EmployeeType? EmployeeType { get; set; }
    
    public int PhoneNumber { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string EmailAdress { get; set; }
    
    public int LoginId { get; set; }
    [JsonIgnore]
    public Login Login { get; set; }

    [JsonIgnore]
    public List<Order>? Orders { get; set; }
}