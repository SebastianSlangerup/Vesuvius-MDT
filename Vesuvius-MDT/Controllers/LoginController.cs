using System.Data;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("/login/{username}/{password}")]
    public ActionResult Login(string username, string password)
    {
        try
        {
            var user = _unitOfWork.LoginRepository.Find(user => user.Username == username && user.Password == password).First();
            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
       
    }

    [Authorize(Policy = "Token_reguired")]
    [HttpGet("/logins")]
    public ActionResult<List<Login>> All()
    {
        var logins = _unitOfWork.LoginRepository.GetAll();
        
        return Ok(logins);
    }
    [Authorize(Policy = "Token_reguired")]
    [HttpGet("/login/{id:int}")]
    public ActionResult<Login> Get(int id)
    {
        var login = _unitOfWork.LoginRepository.GetById(id);

        if (login is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(login);
    }
    [Authorize(Policy = "Token_reguired")]
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
    [Authorize(Policy = "Token_reguired")]
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
