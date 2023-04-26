namespace Vesuvius_MDT.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public int EmployeeTypeId { get; set; }
    public int PhoneNumber { get; set; }
    public string EmailAdress { get; set; }
    public int loginId { get; set; }

    public List<Order>? Order_ids { get; set; }
}