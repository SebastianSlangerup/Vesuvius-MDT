using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class TableController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public TableController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/tables")]
    public ActionResult<List<Table>> All()
    {
        var tables = _unitOfWork.TableRepository.GetAll();
        
        return Ok(tables);
    }
}
