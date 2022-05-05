using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using Nelibur.ObjectMapper;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Business
{
    public abstract class BaseService<TEntity, TFilter, TModel, TEditModel>
        : IService<TEntity, TFilter, TModel, TEditModel>
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
        where TEditModel : BaseModel, new()
        where TFilter : class, IFilter
    {

        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {

            UnitOfWork = unitOfWork;
        }

        public abstract IEnumerable<TModel> Get(TFilter filter=null);

        public abstract TModel Get(Guid id);
        public abstract void Add(TEditModel model);

        public abstract void Update(TEditModel model);

        public abstract void Delete(Guid id);

        protected virtual TModel ToModel<TModel>(TEntity entity) //
            where TModel : BaseModel, new()
        {
            return TinyMapper.Map<TModel>(entity);
        }

        protected virtual TEntity ToEntity<TModel>(TModel model)
            where TModel : BaseModel, new()
        {
            return TinyMapper.Map<TEntity>(model);
        }

        protected virtual void ValidateModel<TModel>(TModel model)
            where TModel : BaseModel, new()
        {
            if (model is null)
            {
                throw new ArgumentException("Model can not be null!");
            }
        }
        protected abstract Expression<Func<TEntity, bool>> GetFilter(TFilter filter);

    }
}
