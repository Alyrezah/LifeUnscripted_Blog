using LifeUnscripted_Blog.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LifeUnscripted_Blog.Persistence.EfCore.Repositories
{
    public class GenericRepository<TKey, T> : IGenericRepository<TKey, T> where T : class
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
        }

        public IReadOnlyList<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetBy(TKey id)
        {
            return _dbContext.Find<T>(id);
        }

        public bool IsExists(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Any(expression);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
