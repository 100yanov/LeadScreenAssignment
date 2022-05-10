using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class FileDbSet<TEntity> : IDbSet<TEntity>
        where TEntity : BaseEntity
    {
        private readonly List<TEntity> set;

        private string name { get; }

        public FileDbSet(List<TEntity> entities, string name)
        {

            this.set = entities;
            this.name = name;
        }
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => this.set.AsQueryable().Expression;

        public IQueryProvider Provider => this.set.AsQueryable().Provider;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return set.GetEnumerator();
        }
        public override string ToString()
        {
            return name;
        }

        public void Add(TEntity entity)
        {
            if (entity.Id == null || entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
                this.set.Add(entity);
            }
            else
            {
                var oldEntity = this.Find(entity.Id);
                oldEntity = entity;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.Id= Guid.NewGuid();
            };
            this.set.AddRange(entities);
        }

        public TEntity Find(Guid id)
        {
            return this.set.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(TEntity entity)
        {
            var e = this.Find(entity.Id);
            this.set.Remove(e);
        }

        public void RemoveRange()
        {
            throw new NotImplementedException();
        }
    }
}
