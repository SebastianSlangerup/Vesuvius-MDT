using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;
[Authorize(Policy = "Token_reguired")]
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

    [HttpPost("order-items/add")]
    public ActionResult<OrderItem> Add(OrderItem orderItem)
    {
        try
        {
            _unitOfWork.OrderItemRepository.Add(orderItem);
            _unitOfWork.Save();
            return Ok(orderItem);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpGet("/order-item/{id:int}")]
    public ActionResult<OrderItem> Get(int id)
    {
        var order_item = _unitOfWork.OrderItemRepository.GetById(id);

        if (order_item is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(order_item);
    }

    [HttpGet("/order-items/ordered/{orderId:int}")]
    public ActionResult<List<OrderItem>> GetOrderedItems(int orderId)
    {
        var orderItems = _unitOfWork.OrderItemRepository.Find(oi => oi.OrderId == orderId && oi.Order.OrderStatusId == 1);

        if (orderItems.Any() == false) return NotFound("No order items were found");

        return Ok(orderItems);
    }

    [HttpPut("/order-item/update/{id:int}")]
    public ActionResult<OrderItem> Update(int id, OrderItem orderRequestItem)
    {
        var Order_item = _unitOfWork.OrderItemRepository.GetById(id);
        if (Order_item == null)
        {
            return NotFound();
        }

        try
        {
            Order_item.OrderId = orderRequestItem.OrderId;
            Order_item.Count = orderRequestItem.Count;
            Order_item.Discount = orderRequestItem.Discount;
            Order_item.Paid = orderRequestItem.Paid;
            Order_item.FoodStatus = orderRequestItem.FoodStatus;
            Order_item.Addons = orderRequestItem.Addons;
            Order_item.FoodStatusId = orderRequestItem.FoodStatusId;
            Order_item.MenuItem = orderRequestItem.MenuItem;
            Order_item.MenuItemId = orderRequestItem.MenuItemId;
            
            _unitOfWork.Save();
            return Ok();
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/order-item/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var order_item = _unitOfWork.OrderItemRepository.GetById(id);
        if (order_item == null)
        {
            return NotFound();
        }

        try
        {
            _unitOfWork.OrderItemRepository.Remove(order_item);
            _unitOfWork.Save();
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
