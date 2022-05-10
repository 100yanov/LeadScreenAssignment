using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext context;

        public UnitOfWork(IDbContext context,
            ILeadRepository leadRepository,
            ISubAreaRepository subAreaRepository)
        {
            this.context = context;
            this.Leads = leadRepository;
            this.SubAreas = subAreaRepository;
        }

        public ILeadRepository Leads { get; }

        public ISubAreaRepository SubAreas { get; }

        public int Complete()
        {         
            return this.context.SaveChanges();
        }

        public void Dispose() => this.context.Dispose();
    }
}
