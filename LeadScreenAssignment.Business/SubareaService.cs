using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using Nelibur.ObjectMapper;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Business
{
    public class SubareaService : BaseService<SubAreaEntity, SubAreaFilter, SubAreaModel, SubAreaEditModel>
    {
        public SubareaService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
        public override IEnumerable<SubAreaModel> Get(SubAreaFilter filter = null)
        {
            IEnumerable<LeadEntity>? entities;
            if (null == filter)
            {
                return UnitOfWork
                   .SubAreas
                   .GetAll(sa => sa.Leads)
                   .Select(e => ToModel<SubAreaModel>(e));
            }
            else
            {
                return UnitOfWork
                  .SubAreas
                  .Find(this.GetFilter(filter), sa => sa.Leads) //remove includes 
                  .Select(e => ToModel<SubAreaModel>(e));
            }          
            
        }
        public override void Delete(Guid id)
        {
            UnitOfWork
                .SubAreas
                .Remove(new() { Id = id });
            UnitOfWork.Complete();
        }

        public override SubAreaModel Get(Guid id)
        {
            return ToModel<SubAreaModel>(UnitOfWork.SubAreas.Get(id));
        }

        public override void Update(SubAreaEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.SubAreas.Add(entity);
            UnitOfWork.Complete();
        }

        public override void Add(SubAreaEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.SubAreas.Add(entity);
            UnitOfWork.Complete();
        }

        protected override Expression<Func<SubAreaEntity, bool>> GetFilter(SubAreaFilter filter)
        {
            return sa => null == filter.PincodeContains || sa.PinCode.Contains(filter.PincodeContains);
        }
    }
}
