using System.Data;
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
    
    [HttpGet("/food-status/{id:int}")]
    public ActionResult<FoodStatus> Get(int id)
    {
        var foodStatus = _unitOfWork.FoodStatusRepository.GetById(id);

        if (foodStatus is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(foodStatus);
    }

    [HttpPost("/food-status/new")]
    public ActionResult<FoodStatus> Add(FoodStatus foodStatus)
    {
        try
        {
            _unitOfWork.FoodStatusRepository.Add(foodStatus);
            _unitOfWork.Save();
            return Ok(foodStatus);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/food-status/{id:int}")]
    public ActionResult<FoodStatus> Update(int id, FoodStatus foodStatusRequest)
    {
        var foodStatus = _unitOfWork.FoodStatusRepository.GetById(id);
        
        if (foodStatus is null) return NotFound();

        try
        {
            foodStatus.Status = foodStatusRequest.Status;

            _unitOfWork.Save();

            return Ok(foodStatus);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
