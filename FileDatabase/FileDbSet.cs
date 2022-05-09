using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileDatabase
{
    public class FileDbSet<T> : IDbSet<T>
        where T : class
    {
        private readonly List<T> set;

        private string name { get;  }

        public FileDbSet(List<T> entities, string name)
        {
            this.set = entities;
            this.name = name;
        }
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
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
    }
}
