using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace UnitTests;


public class UnitOfWorkTest : Controller
{
    private readonly UnitOfWork _unitOfWork;
    
    public UnitOfWorkTest(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }
    
    [Test]
    public void UnitOfWork()
    {
        int id = 1;
        var orderTestModel = _unitOfWork.OrderTestRepository.GetById(id);

        if (orderTestModel is null)
        {
            Assert.Fail();
        }
        
        _unitOfWork.Save();
       Assert.True(true);
    }
}

interface IOrderRepositoryTest <TEntity> where TEntity : class
{
    TEntity? GetById(int id);
}

class OrderRepositoryTest <T> : IOrderRepositoryTest<T> where T : class
{
    internal readonly DataContext _context;
    
    //Dependency Injection
    public OrderRepositoryTest(DataContext context)
    {
        _context = context;
    }
        
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
}

class OrderTestModel
{
    public int id { get; set; } 
}

class UnitOfWork
{
    
    internal readonly DataContext _context;
    
    //Dependency Injection
    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    
    private OrderRepositoryTest<OrderTestModel>? _orderTestModel;
    public OrderRepositoryTest<OrderTestModel> OrderTestRepository => _orderTestModel ??= new OrderRepositoryTest<OrderTestModel>(_context);
    
    public void Save()
    {
        _context.SaveChanges();
    }
}