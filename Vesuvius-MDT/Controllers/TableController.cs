using System.Data;
using Microsoft.AspNetCore.Mvc;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.Models;
using Vesuvius_MDT.UnitOfWorkNamespace;

namespace Vesuvius_MDT.Controllers;

[ApiController]
public class TableController : Controller
{
    private readonly UnitOfWork _unitOfWork;

    public TableController(DataContext context)
    {
        _unitOfWork = new UnitOfWork(context);
    }

    [HttpGet("/tables")]
    public ActionResult<List<Table>> All()
    {
        var tables = _unitOfWork.TableRepository.GetAll();
        
        return Ok(tables);
    }
    
    [HttpGet("/table/{id:int}")]
    public ActionResult<Table> Get(int id)
    {
        var table = _unitOfWork.TableRepository.GetById(id);

        if (table is null) return NotFound();
        
        _unitOfWork.Save();
        return Ok(table);
    }

    [HttpPost("/table/new")]
    public ActionResult<Table> Add(Table table)
    {
        try
        {
            _unitOfWork.TableRepository.Add(table);
            _unitOfWork.Save();
            return Ok(table);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("/table/delete/{id:int}")]
    public ActionResult<Table> Update(int id, Table tableRequest)
    {
        var table = _unitOfWork.TableRepository.GetById(id);
        
        if (table is null) return NotFound();

        try
        {
            table.TableSize = tableRequest.TableSize;
            table.Location = tableRequest.Location;

            _unitOfWork.Save();

            return Ok(table);
        }
        catch (DataException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("/table/delete/{id:int}")]
    public ActionResult Delete(int id)
    {
        var table = _unitOfWork.TableRepository.GetById(id);

        if (table is null) return NotFound();

        try
        {
            _unitOfWork.TableRepository.Remove(table);
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
