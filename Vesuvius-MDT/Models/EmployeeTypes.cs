namespace Vesuvius_MDT.Models;

public class EmployeeTypes
{
    public int EmployeeTypeId { get; set; }
    public string Type { get; set; }

    public List<Employees> Employee_ids { get; set; }
    
    
}