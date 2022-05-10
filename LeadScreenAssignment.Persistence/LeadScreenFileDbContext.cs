using FileDatabase;
using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence
{
    internal class LeadScreenFileDbContext : FileContext
    {
        public LeadScreenFileDbContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<LeadEntity> Leads { get; set; }
        public IDbSet<SubAreaEntity> SubAreas { get; set; }
    }
}
