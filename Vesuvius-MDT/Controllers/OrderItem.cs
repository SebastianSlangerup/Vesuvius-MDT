using System.Data;
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

    [HttpGet("order-items")]
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
            Order_item.AddonLinks = orderRequestItem.AddonLinks;
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
