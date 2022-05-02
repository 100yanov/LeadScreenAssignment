using LeadScreenAssignment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
    
}
