using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Web.Controllers
{
    public class LeadsController : BaseController<LeadEntity, LeadFilter,LeadModel, LeadEditModel>
    {
        public LeadsController(IService<LeadEntity, LeadFilter, LeadModel, LeadEditModel> service)
            : base(service)
        {
        }
    }
}
