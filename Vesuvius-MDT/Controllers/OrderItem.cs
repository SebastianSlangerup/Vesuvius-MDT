using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class OrderItemController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public OrderItemController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/order-items")]
    public ActionResult<List<OrderItem>> All()
    {
        var orderItems = _unitOfWork.OrderItemRepository.GetAll();
        
        return Ok(orderItems);
    }
}
