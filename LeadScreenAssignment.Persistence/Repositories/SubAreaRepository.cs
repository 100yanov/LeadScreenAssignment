using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Data;
using LeadScreenAssignment.Persistence.Interfaces;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class SubAreaRepository : BaseRepository<SubAreaEntity>, ISubAreaRepository
    {
        public SubAreaRepository(IDbContext context) : base(context)
        {
        }        
   
    }
}
