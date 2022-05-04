using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Extensions;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class LeadRepository : BaseRepository<LeadEntity>, ILeadRepository
    {
        public LeadRepository(LeadScreenDbContext context)
            : base(context)
        {
            
        }
        public override IEnumerable<LeadEntity> GetAll(params Expression<Func<LeadEntity, object>>[] includeProperties)
        {
            return base.GetAll();
        }
    }
}
