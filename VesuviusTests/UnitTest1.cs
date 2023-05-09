using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Moq;

namespace VesuviusTests;

[TestClass]
public class UnitOfWorkTest
{
    private readonly UnitOfWork _unitOfWork;
    

    
    public UnitOfWorkTest(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }
    
    [TestMethod]
    public void TestUnitOfWork()
    {
        int id = 1;
        var orderTestModel = _unitOfWork.OrderTestRepository.GetById(id);

        if (orderTestModel is null)
        {
            Assert.Fail();
        }
        
        _unitOfWork.Save();
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void test2()
    {
        Assert.IsTrue(true);
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
        var mockContext = new Mock<DataContext>();
        _context = mockContext;
    }
    
    private OrderRepositoryTest<OrderTestModel>? _orderTestModel;
    public OrderRepositoryTest<OrderTestModel> OrderTestRepository => _orderTestModel ??= new OrderRepositoryTest<OrderTestModel>(_context);
    
    public void Save()
    {
        _context.SaveChanges();
    }
}