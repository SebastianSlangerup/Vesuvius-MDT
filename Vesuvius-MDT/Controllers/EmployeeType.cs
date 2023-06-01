using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
[Authorize(Policy = "Token_reguired")]

public class EmployeeTypeController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public EmployeeTypeController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/employee-types")]
    public ActionResult<List<EmployeeType>> All()
    {
        var employeeTypes = _unitOfWork.EmployeeTypeRepository.GetAll();
        
        return Ok(employeeTypes);
    }
    
    [HttpGet("/employee-type/{id:int}")]
    public ActionResult<EmployeeType> Get(int id)
    {
        var employeeType = _unitOfWork.EmployeeTypeRepository.GetById(id);

        if (employeeType is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(employeeType);
    }

    [HttpPost("/employee-type/new")]
    public ActionResult<EmployeeType> Add(EmployeeType employeeType)
    {
        try
        {
            _unitOfWork.EmployeeTypeRepository.Add(employeeType);
            _unitOfWork.Save();
            return Ok(employeeType);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/employee-type/update/{id:int}")]
    public ActionResult<EmployeeType> Update(int id, EmployeeType employeeTypeRequest)
    {
        var employeeType = _unitOfWork.EmployeeTypeRepository.GetById(id);
        
        if (employeeType is null) return NotFound();

        try
        {
            employeeType.Type = employeeTypeRequest.Type;

            _unitOfWork.Save();

            return Ok(employeeType);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpDelete("/employee-type/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var employeeType = _unitOfWork.EmployeeTypeRepository.GetById(id);
        if (employeeType == null)
        {
            return NotFound();
        }

        try
        {
            _unitOfWork.EmployeeTypeRepository.Remove(employeeType);
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
