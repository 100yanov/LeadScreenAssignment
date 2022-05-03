using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Web.Controllers
{
    public class LeadsController : BaseController<LeadEntity, LeadModel, LeadEditModel>
    {
        public LeadsController(IService<LeadEntity, LeadModel, LeadEditModel> service)
            : base(service)
        {
        }
    }
}
