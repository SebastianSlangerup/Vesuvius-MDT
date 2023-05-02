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
}
