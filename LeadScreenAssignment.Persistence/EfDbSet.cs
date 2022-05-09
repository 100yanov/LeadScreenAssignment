using LeadScreenAssignment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence
{
    public class EfDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> innerSet;
        private static EfDbSet<TEntity>instance;
        private EfDbSet(DbSet<TEntity> set)
        {
            this.innerSet = set;
        }
        public Type ElementType => innerSet.AsQueryable().ElementType;

        public Expression Expression => innerSet.AsQueryable().Expression;

        public IQueryProvider Provider => innerSet.AsQueryable().Provider;

        public void Add(TEntity entity) => this.innerSet.Add(entity);
      

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.innerSet.AddRange(entities);
        }

        public TEntity Find(Guid id)=> this.innerSet.Find(id);
        

        public IEnumerator<TEntity> GetEnumerator()
        {
            return this.innerSet.AsEnumerable().GetEnumerator();
        }

        public void Remove(TEntity entity) 
        { 
            this.innerSet.Remove(entity); 
        }

        public void RemoveRange() => innerSet.RemoveRange();


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerSet.AsEnumerable().GetEnumerator();
        }

        public static IDbSet<TEntity> Instance(DbSet<TEntity> set)
        {
            if (instance is null)
            {
                instance = new EfDbSet<TEntity>(set);
            }
            return instance;
        }
    }
}
