using System.Linq;

namespace LeadScreenAssignment.Data
{
    public interface IDbSet<TEntity> : IDbSet, IQueryable<TEntity>, IEnumerable<TEntity>
        where TEntity : class   
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity Find(Guid id);
        void Remove(TEntity entity);
        void RemoveRange();
    }
    public interface IDbSet
    {

    }
}