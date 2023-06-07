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

    [HttpGet("/orders/in-progress")]
    public ActionResult<Order> GetInProgress()
    {
        const int inProgress = 1;
        var orders = _unitOfWork.OrderRepository.Find(o => o.OrderStatusId == inProgress);

        if (orders.Any() == false) return NotFound("No orders are currently in progress");

        return Ok(orders);
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
    
    [HttpPost("/order/create-reservation-order")]
    public ActionResult<Order> CreateReservationOrder(int reservationId, Dictionary<OrderItem, List<Addon>?> orderItems, int employeeId)
    {
        List<OrderItem> orderItemEnumerable = new List<OrderItem>();
        
        Order order = new Order
        {
            ReservationId = reservationId,
            OrderStatusId = 1, // In progress
            OrderItems = orderItemEnumerable,
            ServerId = employeeId
        };

        foreach (var orderItemKv in orderItems)
        {
            OrderItem orderItem = new OrderItem
            {
                Addons = orderItemKv.Value.ToList(),
                Order = order,
                MenuItem = orderItemKv.Key.MenuItem,
                MenuItemId = orderItemKv.Key.MenuItemId,
                Count = orderItemKv.Key.Count,
                Discount = orderItemKv.Key.Discount,
                FoodStatus = orderItemKv.Key.FoodStatus,
                FoodStatusId = orderItemKv.Key.FoodStatusId
            };
            
            orderItemEnumerable.Add(orderItem);
            _unitOfWork.OrderItemRepository.Add(orderItem);
        }

        _unitOfWork.OrderRepository.Add(order);
        _unitOfWork.Save();
        
        return Ok(order);
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