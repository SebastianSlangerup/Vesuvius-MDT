using System.Data;
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
    
    [HttpGet("/order-status/{id:int}")]
    public ActionResult<OrderStatus> Get(int id)
    {
        var orderStatus = _unitOfWork.OrderStatusRepository.GetById(id);

        if (orderStatus is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(orderStatus);
    }

    [HttpPost("/order-status/new")]
    public ActionResult<OrderStatus> Add(OrderStatus orderStatus)
    {
        try
        {
            _unitOfWork.OrderStatusRepository.Add(orderStatus);
            _unitOfWork.Save();
            return Ok(orderStatus);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/order-status/{id:int}")]
    public ActionResult<OrderStatus> Update(int id, OrderStatus orderStatusRequest)
    {
        var orderStatus = _unitOfWork.OrderStatusRepository.GetById(id);
        
        if (orderStatus is null) return NotFound();

        try
        {
            orderStatus.Status = orderStatusRequest.Status;

            _unitOfWork.Save();

            return Ok(orderStatus);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/order-status/{id:int}")]
    public ActionResult Delete(int id)
    {
        var orderStatus = _unitOfWork.OrderStatusRepository.GetById(id);

        if (orderStatus is null) return NotFound();

        try
        {
            _unitOfWork.OrderStatusRepository.Remove(orderStatus);
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
