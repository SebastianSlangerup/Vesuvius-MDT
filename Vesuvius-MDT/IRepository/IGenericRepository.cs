using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Vesuvius_MDT.IRepository;

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