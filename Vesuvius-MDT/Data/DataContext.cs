using Microsoft.EntityFrameworkCore;
using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=10.130.54.46;Database=vesuvius_test;User Id=Vesuvius;Password=Admin2023;TrustServerCertificate=True;"
            );
    }

    public DbSet<Addon> Addons { get; set; }
    public DbSet<AddonLink> AddonLinks { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<FoodCategory> FoodCategories { get; set; }
    public DbSet<FoodStatus> FoodStatuses { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderStatus> OrderStatuses { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Table> Tables { get; set; }
}