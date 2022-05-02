using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Core.Entities
{
    public class LeadEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Guid SubAreaId { get; set; }
        public virtual SubAreaEntity SubArea { get; set; }
    }
}
