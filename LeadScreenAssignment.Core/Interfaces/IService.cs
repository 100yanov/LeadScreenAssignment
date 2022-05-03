using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Core.Interfaces
{
    public interface IService<TEntity, TModel, TEditModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
        where TEditModel : BaseModel, new()
    {
        IEnumerable<TModel> Get<TModel>()
            where TModel : BaseModel, new();
       
        TModel Get<TModel>(Guid id) 
            where TModel : BaseModel, new();

        void Add<TEditModel>(TEditModel model)
            where TEditModel : BaseModel, new();
       
        void Update<TEditModel>(TEditModel model)
             where TEditModel : BaseModel, new();
        void Delete(Guid id);
    }
}
