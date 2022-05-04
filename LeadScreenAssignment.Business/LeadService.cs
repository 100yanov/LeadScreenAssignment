﻿using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Models;
using LeadScreenAssignment.Persistence.Interfaces;

namespace LeadScreenAssignment.Business
{
    public class LeadService : BaseService<LeadEntity, LeadModel, LeadEditModel>
    {
        public LeadService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public override void Add<LeadEditModel>(LeadEditModel model)
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

        public override IEnumerable<LeadModel> Get<LeadModel>()
        {
            var entities = this.UnitOfWork
                .Leads
                .GetAll(l=>l.SubArea);
            return entities.Select(e => base.ToModel<LeadModel>(e));
        }

        

        public override LeadModel Get<LeadModel>(Guid id)
        {
            return ToModel<LeadModel>(UnitOfWork.Leads.Get(id));
        }

        public override void Update<LeadModel>(LeadModel model)
        {
            ValidateModel(model);
            var entity = ToEntity(model);
            UnitOfWork.Leads.Add(entity);
            UnitOfWork.Complete();
        }

       
    }
}