using System.Data;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class EmployeeController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public EmployeeController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/employees")]
    public ActionResult<List<Employee>> All()
    {
        var employees = _unitOfWork.EmployeeRepository.GetAll();
        
        return Ok(employees);
    }
    
    [HttpGet("/employee/{id:int}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = _unitOfWork.EmployeeRepository.GetById(id);

        if (employee is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(employee);
    }

    [HttpPost("/employee/new")]
    public ActionResult<Employee> Add(Employee employee)
    {
        try
        {
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Save();
            return Ok(employee);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/employee/update/{id:int}")]
    public ActionResult<Employee> Update(int id, Employee employeeRequest)
    {
        var employee = _unitOfWork.EmployeeRepository.GetById(id);
        
        if (employee is null) return NotFound();

        try
        {
            employee.EmployeeName = employeeRequest.EmployeeName;
            employee.EmployeeTypeId = employeeRequest.EmployeeTypeId;
            employee.PhoneNumber = employeeRequest.PhoneNumber;
            employee.EmailAdress = employeeRequest.EmailAdress;

            _unitOfWork.Save();

            return Ok(employee);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    [HttpDelete("/employee/update/{id:int}")]
    public ActionResult Delete(int id)
    {
        var employee = _unitOfWork.EmployeeRepository.GetById(id);
        if (employee == null)
        {
            return NotFound();
        }

        try
        {
            _unitOfWork.EmployeeRepository.Remove(employee);
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
