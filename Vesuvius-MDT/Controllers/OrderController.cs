using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public OrderController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }


    [HttpGet("/orders")]
    public List<Order> All()
    {
        return _unitOfWork.OrderRepository.GetAll().ToList();
    }

    [HttpGet("/order/{id:int}")]
    public ActionResult<Order> Get(int id)
    {
        Order? order = _unitOfWork.OrderRepository.GetById(id);

        if (order is not null)
        {
            return Ok(order);
        }
        return NotFound();
    }

    [HttpPost("/order/new")]
    public ActionResult<Order> Add(Order order)
    {
        _unitOfWork.OrderRepository.Add(order);
        return Ok(order);
    }
}