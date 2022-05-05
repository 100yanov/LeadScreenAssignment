using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;

namespace LeadScreenAssignment.Business
{
    public class LeadService : BaseService<LeadEntity,LeadFilter, LeadModel, LeadEditModel>
    {
        public LeadService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override void Add(LeadEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.Leads.Add(entity);
            UnitOfWork.Complete();
        }

        public override void Delete(Guid id)
        {
            UnitOfWork
                .Leads
                .Remove(new() { Id = id });
            UnitOfWork.Complete();
        }

        public override IEnumerable<LeadModel> Get(LeadFilter filter )
        {
            var entities = this.UnitOfWork
                .Leads
                .GetAll(l => l.SubArea);
            return entities.Select(e => base.ToModel<LeadModel>(e));
        }


        public override LeadModel Get(Guid id)
        {
            return ToModel<LeadModel>(UnitOfWork.Leads.Get(id));
        }

        public override void Update(LeadEditModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.Leads.Add(entity);
            UnitOfWork.Complete();
        }

       
    }
}
