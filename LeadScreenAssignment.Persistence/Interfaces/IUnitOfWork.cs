using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILeadRepository Leads { get; }
        ISubAreaRepository SubAreas { get; }
      
        int Complete();
    }
}
