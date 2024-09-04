using System.Linq.Expressions;

namespace LifeUnscripted_Blog.Domain.Common
{
    public interface IGenericRepository<TKey, T> where T : class
    {
        void Create(T entity);
        T GetBy(TKey id);
        IReadOnlyList<T> GetAll();
        bool IsExists(Expression<Func<T, bool>> expression);
        void Save();
    }
}
