using System.Data;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class MenuItemController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public MenuItemController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/menu-items")]
    public ActionResult<List<MenuItem>> All()
    {
        var menuItems = _unitOfWork.MenuItemRepository.GetAll();
        
        return Ok(menuItems);
    }

    [HttpGet("menu-item/{id:int}")]
    public ActionResult<MenuItem> Get(int id)
    {
        MenuItem menuItem = _unitOfWork.MenuItemRepository.GetById(id);

        if (menuItem == null)
        {
            return NotFound();
        }
        
        _unitOfWork.Save();
        return Ok(menuItem);

    }

    [HttpPost("/menu-item/new")]
    public ActionResult<MenuItem> Add(MenuItem menuItem)
    {
        try
        {
            _unitOfWork.MenuItemRepository.Add(menuItem);
            _unitOfWork.Save();
            return Ok(menuItem);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/menu-item/update/{id:int}")]
    public ActionResult<MenuItem> Update(int id, MenuItem menuItemRequest)
    {
        MenuItem menuItem = _unitOfWork.MenuItemRepository.GetById(id);

        if (menuItem == null)
        {
            return NotFound();
        }

        try
        {
            menuItem.MenuItemId = menuItemRequest.MenuItemId;
            menuItem.OrderItems = menuItemRequest.OrderItems;
            menuItem.Description = menuItemRequest.Description;
            menuItem.Price = menuItemRequest.Price;
            menuItem.InStock = menuItemRequest.InStock;
            menuItem.Name = menuItemRequest.Name;
            
            _unitOfWork.Save();
            return Ok(menuItem);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/menu-item/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var menu_item = _unitOfWork.MenuItemRepository.GetById(id);
        if (menu_item == null)
        {
            return NotFound();
        }

        try
        {
            _unitOfWork.MenuItemRepository.Remove(menu_item);
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
