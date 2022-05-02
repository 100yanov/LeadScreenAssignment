using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence.Interfaces
{
    public interface IUnitOfWork
    {        
        ILeadRepository Leads { get; }
        ISubAreaRepository SubAreas { get; }
        IPinCodeRepository PinCodes { get; }
        int Complete();
    }
}
