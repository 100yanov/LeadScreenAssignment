using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Business
{
    public class LeadService : BaseService<LeadEntity, LeadFilter, LeadModel, LeadEditModel>
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

        public override IEnumerable<LeadModel> Get(LeadFilter filter)
        {
            IEnumerable<LeadEntity>? entities;
            if (filter is null)
            {
             entities = this.UnitOfWork
                .Leads
                .GetAll(l => l.SubArea);
            }
            else
            {
                entities = this.UnitOfWork.Leads.Find(this.GetFilter(filter));
            }
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

        protected override Expression<Func<LeadEntity, bool>> GetFilter(LeadFilter filter)
        {
            throw new NotImplementedException();
        }



    }
}
