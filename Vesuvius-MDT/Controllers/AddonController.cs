using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class AddonController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public AddonController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/addons")]
    public ActionResult<List<Addon>> All()
    {
        var addons = _unitOfWork.AddonRepository.GetAll();
        
        return Ok(addons);
    }

    [HttpGet("/addon/{id:int}")]
    public ActionResult<Addon> Get(int id)
    {
        var addon = _unitOfWork.AddonRepository.GetById(id);

        if (addon is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(addon);
    }

    [HttpPost("/addon/new")]
    public ActionResult<Addon> Add(Addon addon)
    {
        try
        {
            _unitOfWork.AddonRepository.Add(addon);
            _unitOfWork.Save();
            return Ok(addon);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/addon/{id:int}")]
    public ActionResult<Addon> Update(int id, Addon addonRequest)
    {
        var addon = _unitOfWork.AddonRepository.GetById(id);
        
        if (addon is null) return NotFound();

        try
        {
            addon.Name = addonRequest.Name;
            addon.Price = addonRequest.Price;

            _unitOfWork.Save();

            return Ok(addon);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/addon/{id:int}")]
    public ActionResult Delete(int id)
    {
        var addon = _unitOfWork.AddonRepository.GetById(id);

        if (addon is null) return NotFound();

        try
        {
            _unitOfWork.AddonRepository.Remove(addon);
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