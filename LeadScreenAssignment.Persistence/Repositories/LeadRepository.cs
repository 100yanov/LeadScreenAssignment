using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class LeadRepository : BaseRepository<LeadEntity>, ILeadRepository
    {
        public LeadRepository(DbContext context)
            : base(context)
        {
        }
    }
}
