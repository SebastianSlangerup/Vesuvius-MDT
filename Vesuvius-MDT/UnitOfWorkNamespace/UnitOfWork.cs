using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.Repository;

namespace Vesuvius_MDT.UnitOfWorkNamespace;

public class UnitOfWork : IDisposable
{
    private readonly DataContext _context;
    public UnitOfWork(DataContext context)
    {
        this._context = context;
    }

    private GenericRepository<Order>? _orderRepository;
    private GenericRepository<Addon>? _addonRepository;
    private GenericRepository<AddonLink>? _addonLinkRepository;
    private GenericRepository<Customer>? _customerRepository;
    private GenericRepository<Employee>? _employeeRepository;
    private GenericRepository<EmployeeType>? _employeeTypeRepository;
    private GenericRepository<FoodCategory>? _foodCategoryRepository;
    private GenericRepository<FoodStatus>? _foodStatusRepository;
    private GenericRepository<Login>? _loginRepository;
    private GenericRepository<MenuItem>? _menuitemRepository;
    private GenericRepository<OrderItem>? _orderItemRepository;
    private GenericRepository<OrderStatus>? _orderstatusRepository;
    private GenericRepository<Reservation>? _resevationRepository;
    private GenericRepository<Table>? _tableRepository;
    


    public GenericRepository<Order> OrderRepository => _orderRepository ??= new GenericRepository<Order>(_context);
    public GenericRepository<Addon> AddonRepository => _addonRepository ??= new GenericRepository<Addon>(_context);
    public GenericRepository<AddonLink> AddonLinkRepository => _addonLinkRepository ??= new GenericRepository<AddonLink>(_context);
    public GenericRepository<Customer> CustomerRepository => _customerRepository ??= new GenericRepository<Customer>(_context);
    public GenericRepository<Employee> EmployeeRepository => _employeeRepository ??= new GenericRepository<Employee>(_context);
    public GenericRepository<EmployeeType> EmployeeTypeRepository => _employeeTypeRepository ??= new GenericRepository<EmployeeType>(_context);
    public GenericRepository<FoodCategory> FoodCategoryRepository => _foodCategoryRepository ??= new GenericRepository<FoodCategory>(_context);
    public GenericRepository<FoodStatus> FoodStatusRepository => _foodStatusRepository ??= new GenericRepository<FoodStatus>(_context);
    public GenericRepository<Login> LoginRepository => _loginRepository ??= new GenericRepository<Login>(_context);
    public GenericRepository<MenuItem> MenuItemRepository => _menuitemRepository ??= new GenericRepository<MenuItem>(_context);
    public GenericRepository<OrderItem> OrderItemRepository => _orderItemRepository ??= new GenericRepository<OrderItem>(_context);
    public GenericRepository<OrderStatus> OrderStatusRepository => _orderstatusRepository ??= new GenericRepository<OrderStatus>(_context);
    public GenericRepository<Reservation> ReservationRepository => _resevationRepository ??= new GenericRepository<Reservation>(_context);
    public GenericRepository<Table> TableRepository => _tableRepository ??= new GenericRepository<Table>(_context);
    
    
    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;



    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }


    /// <summary>
    /// Performs application-defined tasks associated with freeing,
    /// releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose();
        GC.SuppressFinalize(this);
    }
}