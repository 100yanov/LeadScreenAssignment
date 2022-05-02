using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence.Repositories
{
    public class SubAreaRepository : BaseRepository<SubAreaEntity>, ISubAreaRepository
    {
        public SubAreaRepository(DbContext context) : base(context)
        {
        }
    }
}
