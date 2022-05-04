using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using Nelibur.ObjectMapper;

namespace LeadScreenAssignment.Business
{
    public abstract class BaseService<TEntity, TModel, TEditModel> : IService<TEntity, TModel, TEditModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
        where TEditModel : BaseModel, new()
    {
        
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {        
            
            UnitOfWork = unitOfWork;
        }

        public abstract IEnumerable<TModel> Get<TModel>()
             where TModel : BaseModel, new();
        public abstract TModel Get<TModel>(Guid id)
            where TModel : BaseModel, new();
        public abstract void Add<TEditModel>(TEditModel model)
            where TEditModel : BaseModel, new();

        public abstract void Update<TEditModel>(TEditModel model)
            where TEditModel : BaseModel, new();

        public abstract void Delete(Guid id);

        protected virtual TModel ToModel<TModel>(TEntity entity)
            where TModel : BaseModel, new()
        {
            return TinyMapper.Map<TModel>(entity);
        }

        protected virtual TEntity ToEntity<TModel>(TModel model)
            where TModel : BaseModel, new()        
        {            
            return TinyMapper.Map<TEntity>(model);
        }

        protected virtual void ValidateModel<TEditModel>(TEditModel model)            
        {
            if (model is null)
            {
                throw new ArgumentException("Model can not be null!");
            }
        } 


    }
}
