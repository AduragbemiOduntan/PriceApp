using Microsoft.EntityFrameworkCore;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PriceApp_Infrastructure.Repositories.Implementations
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataBaseContext _context;
        public RepositoryBase(DataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ?
                _context.Set<T>().AsNoTracking() :
                _context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? 
                _context.Set<T>().Where(expression).AsNoTracking() :
                _context.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
