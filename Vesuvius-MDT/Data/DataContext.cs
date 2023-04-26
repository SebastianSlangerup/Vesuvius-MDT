using Microsoft.EntityFrameworkCore;

namespace Vesuvius_MDT.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=10.130.54.46;Database=vesuvius_test;User Id=Vesuvius;Password=Admin2023;TrustServerCertificate=True;"
            );
    }
}