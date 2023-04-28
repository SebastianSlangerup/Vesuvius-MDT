using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class AddonController : Controller
{
    private UnitOfWork _unitOfWork = new UnitOfWork();

    [HttpGet("/addons")]
    public ActionResult<List<Addon>> All()
    {
        var addons = _unitOfWork.AddonRepository.GetAll();
        
        return Ok(addons);
    }

}