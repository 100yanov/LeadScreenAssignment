using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using Nelibur.ObjectMapper;

namespace LeadScreenAssignment.Business
{
    public class SubareaService : BaseService<SubAreaEntity, SubAreaFilter, SubAreaModel, SubAreaEditModel>
    {
        public SubareaService(IUnitOfWork unitOfWork)
            : base( unitOfWork)
        {
        }
        public override IEnumerable<SubAreaModel> Get(SubAreaFilter filter =null)
        {
            return UnitOfWork
                .SubAreas
                .GetAll(sa=>sa.Leads)
                .Select(e => ToModel<SubAreaModel>(e));
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
    }
}
