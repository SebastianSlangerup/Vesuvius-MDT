using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Dtos;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class ReservationController : Controller
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public ReservationController(DataContext context, IConfiguration configuration)
    {
        _configuration = configuration;
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

    // [HttpGet("/reservations/customer/{date:datetime}")]
    // public ActionResult<List<Reservation>> GetReservationForCurrentDate(DateTime date)
    // {
    //     var reservations =
    //         _unitOfWork.ReservationRepository.Find(reservation => reservation.CustomerRefId == customerId);

    //     if (reservations.Any() == false) return NotFound();

    //     return Ok(reservations);
    // }
    [Authorize(Policy = "Token_reguired")]
    [HttpPost("/reservation/new")]
    public ActionResult<Reservation> Add(ReservationDto reservation)
    {
        try
        {
            var connectionString = _configuration["Db:ConnectionString"];
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("relationalInsertIntoReservations", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TableId", SqlDbType.Int).Value = reservation.TableId;
                sqlCommand.Parameters.AddWithValue("@ReservationDateTime", SqlDbType.DateTime).Value = reservation.ReservationDateTime;
                sqlCommand.Parameters.AddWithValue("@ResevationStart", SqlDbType.DateTime).Value = reservation.ResevationStart;
                sqlCommand.Parameters.AddWithValue("@ResevationEnd", SqlDbType.DateTime).Value = reservation.ResevationEnd;
                sqlCommand.Parameters.AddWithValue("@CustomerRefId", SqlDbType.Int).Value = reservation.CustomerRefId;
                sqlCommand.Parameters.AddWithValue("@Extra", SqlDbType.NVarChar).Value = reservation.Extra;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return Ok();
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
