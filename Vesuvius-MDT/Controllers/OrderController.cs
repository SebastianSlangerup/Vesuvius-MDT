using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;

namespace Vesuvius_MDT.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly DataContext _context;

    public OrderController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("/orders")]
    public List<Order> All()
    {
        return _context.Orders.ToList();
    }

    [HttpGet("/order/{id:int}")]
    public ActionResult<Order> Get(int id)
    {
        Order? order = _context.Orders.Find(id);
        if (order is not null)
        {
            return Ok(order);
        }

        return BadRequest();
    }

    [HttpPost("/order/new")]
    public ActionResult<Order> Add(Order order)
    {
        _context.Add(order);
        
        return Ok(order);
    }
}