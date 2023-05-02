using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class LoginController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public LoginController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/logins")]
    public ActionResult<List<Login>> All()
    {
        var logins = _unitOfWork.LoginRepository.GetAll();
        
        return Ok(logins);
    }
}
