using LeadScreenAssignment.Core.Interfaces;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface IRepository<T, TKey> where T : IBaseEntity<TKey>
        where TKey : struct
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T Get(TKey id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
