using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vesuvius_MDT.Data;

namespace VesuviusTests;

[TestClass]
public class UnitTest2
{
    private readonly Vesuvius_MDT.UnitOfWorkNamespace.UnitOfWork _unitOfWork;

    public UnitTest2(DataContext context)
    {
        _unitOfWork = new Vesuvius_MDT.UnitOfWorkNamespace.UnitOfWork(context);
    }
    
    [TestMethod]
    public void TestMethod()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddDbContext<DbContext>();

        // Act
        var customer = _unitOfWork.CustomerRepository.GetById(1);

        // Assert
        Assert.AreEqual("Sebastian Møller", customer?.Name);
    }
}