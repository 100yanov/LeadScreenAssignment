using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Core.Models
{
    public class LeadEditModel : BaseModel
    {
        public string Name { get; set; }
        public Guid SubAreaId { get; set; }
    }
}
