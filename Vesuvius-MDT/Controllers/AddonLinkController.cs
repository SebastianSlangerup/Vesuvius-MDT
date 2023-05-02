using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class AddonLinkController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public AddonLinkController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/addon-links")]
    public ActionResult<List<AddonLink>> All()
    {
        var addonLinks = _unitOfWork.AddonLinkRepository.GetAll();
        
        return Ok(addonLinks);
    }
}