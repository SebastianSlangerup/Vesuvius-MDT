using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class EmployeeController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public EmployeeController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/employees")]
    public ActionResult<List<Employee>> All()
    {
        var employees = _unitOfWork.EmployeeRepository.GetAll();
        
        return Ok(employees);
    }
}
