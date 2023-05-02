using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class OrderStatusController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public OrderStatusController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/order-statuses")]
    public ActionResult<List<OrderStatus>> All()
    {
        var orderStatuses = _unitOfWork.OrderStatusRepository.GetAll();
        
        return Ok(orderStatuses);
    }
}
