using System.Data;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class CustomerController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public CustomerController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/customers")]
    public ActionResult<List<Customer>> All()
    {
        var customers = _unitOfWork.CustomerRepository.GetAll();
        
        return Ok(customers);
    }
    
    [HttpGet("/customer/{id:int}")]
    public ActionResult<Customer> Get(int id)
    {
        var customer = _unitOfWork.CustomerRepository.GetById(id);

        if (customer is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(customer);
    }

    [HttpPost("/customer/new")]
    public ActionResult<Customer> Add(Customer customer)
    {
        try
        {
            _unitOfWork.CustomerRepository.Add(customer);
            _unitOfWork.Save();
            return Ok(customer);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/customer/{id:int}")]
    public ActionResult<Customer> Update(int id, Customer customerRequest)
    {
        var customer = _unitOfWork.CustomerRepository.GetById(id);
        
        if (customer is null) return NotFound();

        try
        {
            customer.Email = customerRequest.Email;
            customer.Name = customerRequest.Name;
            customer.PhoneNumber = customerRequest.PhoneNumber;

            _unitOfWork.Save();

            return Ok(customer);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
