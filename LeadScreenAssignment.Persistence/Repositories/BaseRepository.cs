using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using LeadScreenAssignment.Persistence.Extensions;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : ILeadScreenAssignmentRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IDbContext context;
        protected readonly IDbSet<TEntity> set;
        //TODO: add async methods
        public BaseRepository(IDbContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
           
        }

        public virtual void Add(TEntity entity) => this.set.Add(entity);

        public virtual void AddRange(IEnumerable<TEntity> entities)
            => this.set.AddRange(entities);

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, 
            params Expression<Func<TEntity, object>>[] includeProperties) => 
            this.set.IncludeMultiple(includeProperties)
                .Where(predicate)
                .ToList();

        public virtual TEntity Get(Guid id) => //TODO: load included entities
            this.set.Find(id);

      
        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = this.set.IncludeMultiple(includeProperties);            
            return query.ToList();
        }

        public virtual void Remove(TEntity entity) => this.set.Remove(entity);

        public virtual void RemoveRange(IEnumerable<TEntity> entities) => this.set.RemoveRange();

    }
}