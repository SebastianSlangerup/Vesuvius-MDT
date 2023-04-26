using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string EmployeeName { get; set; }
    
    public int? EmployeeTypeId { get; set; }
    public EmployeeType? EmployeeType { get; set; }
    
    public int PhoneNumber { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string EmailAdress { get; set; }
    
    public int LoginId { get; set; }
    public Login Login { get; set; }

    public List<Order>? Orders { get; set; }
}