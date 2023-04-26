namespace Vesuvius_MDT.Models;

public class Login
{
    public int loginId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public Employees Employee_id { get; set; }
}