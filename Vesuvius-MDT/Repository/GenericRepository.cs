using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Vesuvius_MDT.Data;
using Vesuvius_MDT.IRepository;

namespace Vesuvius_MDT.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal readonly DataContext _context;
    
    //Dependency Injection
    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public IIncludableQueryable<T, IEnumerable> Include(Expression<Func<T, IEnumerable>> expression)
    {
        return _context.Set<T>().Include(expression);
    }
}