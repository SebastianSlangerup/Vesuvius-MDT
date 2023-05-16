using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Vesuvius_MDT.IRepository;

/* This projects use of repository pattern.
 * We have chosen to build one interface and one implementation of it called "GenericRepository"
 * from where we will inherit from.
 *
 * This is done against the best practice of an interface foreach repository
 * In this case it adds unwanted complexity.
 *
 * Official doc:
 * https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
 */

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity? GetById(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}