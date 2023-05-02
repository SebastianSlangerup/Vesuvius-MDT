using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class FoodCategoryController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public FoodCategoryController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/food-categories")]
    public ActionResult<List<FoodCategory>> All()
    {
        var foodCategories = _unitOfWork.FoodCategoryRepository.GetAll();
        
        return Ok(foodCategories);
    }
}
