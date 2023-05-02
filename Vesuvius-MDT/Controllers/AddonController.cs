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

    [HttpPost("/addons/new")]
    public ActionResult<Addon> Create(Addon addon)
    {
        try
        {
            _unitOfWork.AddonRepository.Add(addon);
            return Ok(addon);
        }
        catch (DataException e)
        {
            return BadRequest(e);
        }
    }
}