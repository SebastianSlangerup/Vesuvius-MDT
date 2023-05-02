using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class CustomerController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public CustomerController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/customers")]
    public ActionResult<List<Customer>> All()
    {
        var customers = _unitOfWork.CustomerRepository.GetAll();
        
        return Ok(customers);
    }
}
