using System.Linq;

namespace FileDatabase
{
    public interface IDbSet<T>: IDbSet, IQueryable, IEnumerable<T>
        where T : class
    {
        string Name { get;}
    }
    public interface IDbSet
    {

    }
}