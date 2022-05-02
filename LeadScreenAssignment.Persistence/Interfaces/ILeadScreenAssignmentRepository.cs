using LeadScreenAssignment.Core.Entities;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface ILeadScreenAssignmentRepository<T> : IRepository<T, Guid>
        where T : BaseEntity
    {
    }
}
