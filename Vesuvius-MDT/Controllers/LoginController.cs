using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[Authorize(Policy = "Token_reguired")]
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
    
    [HttpGet("/login/{id:int}")]
    public ActionResult<Login> Get(int id)
    {
        var login = _unitOfWork.LoginRepository.GetById(id);

        if (login is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(login);
    }

    [HttpPost("/login/new")]
    public ActionResult<Login> Add(Login login)
    {
        try
        {
            _unitOfWork.LoginRepository.Add(login);
            _unitOfWork.Save();
            return Ok(login);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/login/update/{id:int}")]
    public ActionResult<Login> Update(int id, Login loginRequest)
    {
        var login = _unitOfWork.LoginRepository.GetById(id);
        
        if (login is null) return NotFound();

        try
        {
            login.Username = loginRequest.Username;
            login.Password = loginRequest.Password;

            _unitOfWork.Save();

            return Ok(login);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
