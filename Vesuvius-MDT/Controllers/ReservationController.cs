using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<Reservation> Add(NewReservationDto dto)
    {
        try
        {
            var customer = _unitOfWork.CustomerRepository.Find(c => c.PhoneNumber == dto.PhoneNumber).ToList();
            int customerId;

            // If a customer is found, they have the same phone number as the one that was sent.
            if (customer.Any())
            {
                customerId = customer.First().CustomerId;
            }
            else
            {
                Customer customerInstance = new Customer
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };
                _unitOfWork.CustomerRepository.Add(customerInstance);
                _unitOfWork.Save();

                // Now that the customer has been added, we need to grab their database id
                // and put into our new reservation
                customerId = _unitOfWork.CustomerRepository
                    .Find(c => c.PhoneNumber == dto.PhoneNumber)
                    .First()
                    .CustomerId;
            }

            Reservation reservation = new Reservation
            {
                Customer = customer.First(),
                CustomerRefId = customerId,
                ReservationDateTime = DateTime.Now,
                ResevationStart = dto.ReservationStart,
                ResevationEnd = dto.ReservationStart.AddHours(2),
                Tables = dto.Tables
            };

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
            reservation.Tables = reservationRequest.Tables;
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