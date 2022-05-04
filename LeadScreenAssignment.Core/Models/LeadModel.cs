using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Core.Models
{
    public class LeadModel : BaseModel
    {       
        public string Name { get; set; }

        public SubAreaEditModel SubArea { get; set; }       
    }
}
