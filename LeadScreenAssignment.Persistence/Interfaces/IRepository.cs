using LeadScreenAssignment.Core.Interfaces;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : IBaseEntity<TKey>
        where TKey : struct
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Get(TKey id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll(params string[] includes);
    }
}
