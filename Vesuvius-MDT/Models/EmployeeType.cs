namespace Vesuvius_MDT.Models;

public class EmployeeType
{
    public int EmployeeTypeId { get; set; }
    
    public string Type { get; set; }
    
    public List<Employee> Employees { get; set; }
}