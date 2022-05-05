using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Filters;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Web.Controllers
{
    public class SubareasController : BaseController<SubAreaEntity, SubAreaFilter, SubAreaModel,SubAreaEditModel>
    {
        public SubareasController(IService<SubAreaEntity, SubAreaFilter,SubAreaModel, SubAreaEditModel> service) : base(service)
        {
        }
    }
}
