using LeadScreenAssignment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Core.Filters
{
    public class SubAreaFilter : IFilter
    {
        public string? PincodeContains { get; set; }
    }
}
