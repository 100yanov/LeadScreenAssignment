using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using LeadScreenAssignment.Persistence.Interfaces;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class LeadRepository : BaseRepository<LeadEntity>, ILeadRepository
    {
        public LeadRepository(IDbContext context)
            : base(context)
        {
            
        }      
    }
}
