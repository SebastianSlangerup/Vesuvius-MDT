using Microsoft.EntityFrameworkCore;
using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Data;

public class DataContext : DbContext
{
    private IConfiguration _configuration;
    
    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            _configuration["Db:ConnectionString"]
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ON DELETE NO ACTION
        modelBuilder.Entity<Order>()
            .HasOne(e => e.Reservation)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Reservation>()
            .HasOne(e => e.Customer)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        
        // SEEDING 
        modelBuilder.Entity<Addon>().HasData(
            new Addon { Name = "Pepperoni", Price = 9.99m },
            new Addon { Name = "Salad", Price = 5.00m },
            new Addon { Name = "Cheese", Price = 6.00m}
        );
        modelBuilder.Entity<FoodStatus>().HasData(
            new FoodStatus { Status = "Available"},
            new FoodStatus { Status = "In progress"},
            new FoodStatus { Status = "Done"}
        );
        modelBuilder.Entity<FoodCategory>().HasData(
            new FoodCategory { Name = "Breakfast"},
            new FoodCategory { Name = "Dinner"}
        );
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem
            {
                Name = "Vesuvius Burger",
                Description = "Bøf af hakket oksekød i briochebolle med salat, pickles, tomat, syltede rødløg og burgerdressing.",
                Price = 139,
                
            }
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