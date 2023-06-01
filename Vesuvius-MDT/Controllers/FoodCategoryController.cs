using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
[Authorize(Policy = "Token_reguired")]
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
    
    [HttpGet("/food-category/{id:int}")]
    public ActionResult<FoodCategory> Get(int id)
    {
        var foodCategory = _unitOfWork.FoodCategoryRepository.GetById(id);

        if (foodCategory is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(foodCategory);
    }

    [HttpPost("/food-category/new")]
    public ActionResult<FoodCategory> Add(FoodCategory foodCategory)
    {
        try
        {
            _unitOfWork.FoodCategoryRepository.Add(foodCategory);
            _unitOfWork.Save();
            return Ok(foodCategory);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/food-category/update/{id:int}")]
    public ActionResult<FoodCategory> Update(int id, FoodCategory foodCategoryRequest)
    {
        var foodCategory = _unitOfWork.FoodCategoryRepository.GetById(id);
        
        if (foodCategory is null) return NotFound();

        try
        {
            foodCategory.Name = foodCategoryRequest.Name;

            _unitOfWork.Save();

            return Ok(foodCategory);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpDelete("/food-category/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var foodCategory = _unitOfWork.FoodCategoryRepository.GetById(id);
        if (foodCategory == null)
        {
            return NotFound();
        }

        try
        {
            _unitOfWork.FoodCategoryRepository.Remove(foodCategory);
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
