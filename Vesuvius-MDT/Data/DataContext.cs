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
            new Addon { AddonId = 1, Name = "Pepperoni", Price = 9.99m },
            new Addon { AddonId = 2, Name = "Salad", Price = 5.00m },
            new Addon { AddonId = 3, Name = "Cheese", Price = 6.00m}
        );
        modelBuilder.Entity<FoodStatus>().HasData(
            new FoodStatus { FoodStatusId = 1, Status = "Available"},
            new FoodStatus { FoodStatusId = 2, Status = "In progress"},
            new FoodStatus { FoodStatusId = 3, Status = "Done"}
        );
        modelBuilder.Entity<FoodCategory>().HasData(
            new FoodCategory { FoodCategoryId = 1, Name = "Breakfast"},
            new FoodCategory { FoodCategoryId = 2, Name = "Dinner"}
        );
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem
            {
                MenuItemId = 1,
                Name = "Vesuvius Burger",
                Description = "Bøf af hakket oksekød i briochebolle med salat, pickles, tomat, syltede rødløg og burgerdressing.",
                Price = 139,
                FoodCategoryId = 2,
                InStock = true
            }
        );
        modelBuilder.Entity<OrderStatus>().HasData(
            new OrderStatus { OrderStatusId = 1, Status = "In Progress" },
            new OrderStatus { OrderStatusId = 2, Status = "Done" }
        );
        modelBuilder.Entity<Table>().HasData(
            new Table { TableId = 1, TableSize = 2, Location = "Zone 3" },
            new Table { TableId = 2, TableSize = 4, Location = "Zone 3" }
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, Name = "Sebastian Møller", PhoneNumber = "4528994940", Email = "marsmanden1@gmail.com"},
            new Customer { CustomerId = 2, Name = "Martin Egeskov", PhoneNumber = "4511223344", Email = "mart377i@gmail.com" }
        );
        modelBuilder.Entity<Reservation>().HasData(
            new Reservation
            {
                ReservationId = 1,
                TableId = 1,
                ReservationDateTime = DateTime.Now,
                ResevationStart = DateTime.Now.AddHours(1),
                ResevationEnd = DateTime.Now.AddHours(5),
                CustomerRefId = 1,
                Extra = "Plads til handikap, tak :)"
            }
        );
        modelBuilder.Entity<Login>().HasData(
            new Login { LoginId = 1, Username = "TestUser", Password = "Admin2023" }
        );
        modelBuilder.Entity<EmployeeType>().HasData(
            new EmployeeType { EmployeeTypeId = 1, Type = "Manager"},
            new EmployeeType { EmployeeTypeId = 2, Type = "Chef" }
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1, 
                EmployeeName = "Sebastian Møller", 
                EmployeeTypeId = 1, 
                PhoneNumber = 28994940, 
                EmailAdress = "marsmanden1@gmail.com", 
                LoginId = 1
            }
        );
        modelBuilder.Entity<Order>().HasData(
            new Order { OrderId = 1, OrderStatusId = 1, CustomerId = 1, ServerId = 1, ReservationId = 1, Tips = 2.50m }
        );
        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { OrderItemId = 1, OrderId = 1, MenuItemId = 1, FoodStatusId = 1, Count = 2, Paid = 140.99m }
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