using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public abstract class BaseRepository<T> : ILeadScreenAssignmentRepository<T>
        where T : BaseEntity
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> set;

        //TODO: add async methods
        //TODO: extract interface to abstract leadscreenDbContxt's functionality
        public BaseRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual void Add(T entity) => this.set.Add(entity);

        public virtual void AddRange(IEnumerable<T> entities)
            => this.set.AddRange(entities);

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => this.set
                .Where(predicate)
                .ToList();

        public virtual T Get(Guid id) =>
            this.set.Find(id);

        public virtual IEnumerable<T> GetAll(params string[] includes)
        {
            var result = this.set.AsQueryable();
            foreach (var include in includes)
            {
                result = result.Include(include);
            }
            return result.ToList();
        }


        public virtual void Remove(T entity) => this.set.Remove(entity);

        public virtual void RemoveRange(IEnumerable<T> entities) => this.set.RemoveRange();
    }
}
