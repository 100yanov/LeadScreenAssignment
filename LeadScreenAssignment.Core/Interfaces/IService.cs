using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Core.Interfaces
{
    public interface IService<TEntity, TFilter, TModel, TEditModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
        where TEditModel : BaseModel, new()
         where TFilter : class, IFilter
    {
        IEnumerable<TModel> Get(TFilter filter);


        TModel Get(Guid id);

        void Add(TEditModel model);
       
        void Update(TEditModel model);
        void Delete(Guid id);
    }
}
