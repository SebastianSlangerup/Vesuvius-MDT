using System.ComponentModel.DataAnnotations.Schema;

namespace Vesuvius_MDT.Models;

public class Login
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    
    public int LoginId { get; set; }
    
    [Column(TypeName = "nvarchar(50)")]
    public string Username { get; set; }
    
    [Column(TypeName = "nvarchar(255)")]
    public string Password { get; set; }
}