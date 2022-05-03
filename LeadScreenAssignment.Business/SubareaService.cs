using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using Nelibur.ObjectMapper;

namespace LeadScreenAssignment.Business
{
    public class SubareaService : BaseService<SubAreaEntity, SubAreaModel, SubAreaEditModel>
    {
        public SubareaService(IUnitOfWork unitOfWork)
            : base( unitOfWork)
        {
        }



        public override IEnumerable<SubAreaModel> Get<SubAreaModel>()
        {
            return UnitOfWork
                .SubAreas
                .GetAll()
                .Select(e => ToModel<SubAreaModel>(e));
        }
       

        public override void Delete(Guid id)
        {
            UnitOfWork
                .SubAreas
                .Remove(new() { Id = id });
            UnitOfWork.Complete();
        }

        public override SubAreaModel Get<SubAreaModel>(Guid id)
        {
            return ToModel<SubAreaModel>(UnitOfWork.SubAreas.Get(id));
        }

        public override void Update<SubAreaEditModel>(SubAreaEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.SubAreas.Add(entity);
            UnitOfWork.Complete();
        }

        public override void Add<SubAreaEditModel>(SubAreaEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.SubAreas.Add(entity);
            UnitOfWork.Complete();
        }
    }
}
