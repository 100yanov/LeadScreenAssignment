using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class BaseFileRepository<TEntity> : ILeadScreenAssignmentRepository<TEntity>
        where TEntity : BaseEntity
    {
        //this.set = context.Set<TEntity>();
        //public BaseFileRepository(IDbContext context)
        //{
        //    this.context = context;
        //}

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}