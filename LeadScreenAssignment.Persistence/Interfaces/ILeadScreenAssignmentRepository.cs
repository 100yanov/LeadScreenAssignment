using LeadScreenAssignment.Core.Entities;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface ILeadScreenAssignmentRepository<TEntity> : IRepository<TEntity, Guid>
        where TEntity : BaseEntity
    {
      
    }
}
