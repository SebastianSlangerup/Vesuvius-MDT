using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    [HttpGet("/reservation/{id:int}")]
    public ActionResult<Reservation> Get(int id)
    {
        var reservation = _unitOfWork.ReservationRepository.GetById(id);

        if (reservation is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(reservation);
    }

    [HttpGet("/reservations/active")]
    public ActionResult<List<Reservation>> GetActives()
    {
        var reservations = 
            _unitOfWork.ReservationRepository.Find(reservation => reservation.ResevationEnd < DateTime.Now);

        if (reservations.Any() == false) return NotFound();

        return Ok(reservations);
    }

    [HttpGet("/reservations/customer/{customerId:int}")]
    public ActionResult<List<Reservation>> GetCustomerReservations(int customerId)
    {
        var reservations =
            _unitOfWork.ReservationRepository.Find(reservation => reservation.CustomerRefId == customerId);

        if (reservations.Any() == false) return NotFound();

        return Ok(reservations);
    }

    [HttpGet("/reservations/1-month-ahead")]
    public ActionResult<List<Reservation>> GetReservationsAMonthAhead(int intevals,int inteval_len)
    {

        Calender cl = new Calender(intevals, inteval_len);

        Dictionary<Day, List<Interval>> avaviable_days = cl.get_available(cl.Days);

        if (avaviable_days.Count <= 0)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        Console.WriteLine(avaviable_days.Count);
        
        return Ok(avaviable_days);
    }



    
    // [HttpGet("/reservations/customer/{date:datetime}")]
    // public ActionResult<List<Reservation>> GetReservationForCurrentDate(DateTime date)
    // {
    //     var reservations =
    //         _unitOfWork.ReservationRepository.Find(reservation => reservation.CustomerRefId == customerId);

    //     if (reservations.Any() == false) return NotFound();

    //     return Ok(reservations);
    // }
    
    [HttpPost("/reservation/new")]
    public ActionResult<Reservation> Add(Reservation reservation)
    {
        try
        {
            _unitOfWork.ReservationRepository.Add(reservation);
            _unitOfWork.Save();
            return Ok(reservation);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/reservation/update/{id:int}")]
    public ActionResult<Reservation> Update(int id, Reservation reservationRequest)
    {
        var reservation = _unitOfWork.ReservationRepository.GetById(id);
        
        if (reservation is null) return NotFound();

        try
        {
            reservation.TableId = reservationRequest.TableId;
            reservation.CustomerRefId = reservationRequest.CustomerRefId;
            reservation.Extra = reservationRequest.Extra;
            reservation.ResevationStart = reservationRequest.ResevationStart;
            reservation.ResevationEnd = reservationRequest.ResevationEnd;
            reservation.ReservationDateTime = reservationRequest.ReservationDateTime;

            _unitOfWork.Save();

            return Ok(reservation);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/reservation/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var reservation = _unitOfWork.ReservationRepository.GetById(id);

        if (reservation is null) return NotFound();

        try
        {
            _unitOfWork.ReservationRepository.Remove(reservation);
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
