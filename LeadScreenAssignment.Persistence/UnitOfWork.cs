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
        private readonly DbContext context;

        public UnitOfWork(DbContext context,
            ILeadRepository leadRepository,            
            ISubAreaRepository subAreaRepository)
        {
            this.context = context;
            this.Leads = leadRepository;
            this.SubAreas = subAreaRepository;
        }

        public ILeadRepository Leads { get; }

        public ISubAreaRepository SubAreas { get; }

        

        public int Complete()=>
            this.context.SaveChanges();


        public void Dispose() => this.context.Dispose();
    }
}
