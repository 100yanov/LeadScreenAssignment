using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class PinCodeRepository : BaseRepository<PinCodeEntity>, IPinCodeRepository
    {
        public PinCodeRepository(DbContext context) : base(context)
        {
        }
    }
}
