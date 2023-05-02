using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
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
}
