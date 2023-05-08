using System.Data;
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
    
    [HttpGet("/addon-link/{id:int}")]
    public ActionResult<AddonLink> Get(int id)
    {
        var addonLink = _unitOfWork.AddonLinkRepository.GetById(id);

        if (addonLink is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(addonLink);
    }

    [HttpPost("/addon-link/new")]
    public ActionResult<AddonLink> Add(AddonLink addonLink)
    {
        try
        {
            _unitOfWork.AddonLinkRepository.Add(addonLink);
            _unitOfWork.Save();
            return Ok(addonLink);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/addon-link/update/{id:int}")]
    public ActionResult<AddonLink> Update(int id, AddonLink addonLinkRequest)
    {
        var addonLink = _unitOfWork.AddonLinkRepository.GetById(id);
        
        if (addonLink is null) return NotFound();

        try
        {
            addonLink.AddonId = addonLinkRequest.AddonId;
            addonLink.OrderItemId = addonLinkRequest.OrderItemId;

            _unitOfWork.Save();

            return Ok(addonLink);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/addon/delete/{id:int}")]
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