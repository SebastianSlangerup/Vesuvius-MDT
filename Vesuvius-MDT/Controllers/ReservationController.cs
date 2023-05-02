using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class ReservationController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public ReservationController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/reservations")]
    public ActionResult<List<Reservation>> All()
    {
        var reservations = _unitOfWork.ReservationRepository.GetAll();
        
        return Ok(reservations);
    }
}
