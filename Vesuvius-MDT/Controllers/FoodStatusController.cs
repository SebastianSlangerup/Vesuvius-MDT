using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class FoodStatusController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public FoodStatusController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/food-statuses")]
    public ActionResult<List<FoodStatus>> All()
    {
        var foodStatuses = _unitOfWork.FoodStatusRepository.GetAll();
        
        return Ok(foodStatuses);
    }
}
