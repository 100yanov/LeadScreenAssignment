using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public void Add(T entity)=> this.set.Add(entity);

        public void AddRange(IEnumerable<T> entities) 
            => this.set.AddRange(entities);

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => this.set
                .Where(predicate)
                .ToList();

        public T Get(Guid id) =>
            this.set.Find(id);

        public IEnumerable<T> GetAll() =>
            this.set.ToList();

        public void Remove(T entity) => this.set.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities)=>this.set.RemoveRange();
    }
}
