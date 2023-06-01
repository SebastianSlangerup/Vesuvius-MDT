using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
[Authorize(Policy = "Token_reguired")]
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
        var order = _unitOfWork.OrderRepository.GetById(id);

        if (order is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(order);
    }

    [HttpPost("/order/new")]
    public ActionResult<Order> Add(Order order)
    {
        try
        {
            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.Save();
            return Ok(order);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/order/update/{id:int}")]
    public ActionResult<Order> Update(int id, Order orderRequest)
    {
        var order = _unitOfWork.OrderRepository.GetById(id);
        
        if (order is null) return NotFound();

        try
        {
            order.OrderStatusId = orderRequest.OrderStatusId;
            order.ReservationId = orderRequest.ReservationId;
            order.ServerId = orderRequest.ServerId;
            order.CustomerId = orderRequest.CustomerId;
            
            _unitOfWork.Save();

            return Ok(order);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/order/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var order = _unitOfWork.OrderRepository.GetById(id);

        if (order is null) return NotFound();

        try
        {
            _unitOfWork.OrderRepository.Remove(order);
            _unitOfWork.Save();
            return Ok();
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}