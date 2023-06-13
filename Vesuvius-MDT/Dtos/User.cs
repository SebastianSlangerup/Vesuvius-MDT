namespace Vesuvius_MDT.Dtos
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool IsActive { get; set; }
    }
}
