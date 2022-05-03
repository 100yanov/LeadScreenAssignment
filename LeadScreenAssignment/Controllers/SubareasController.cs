using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;

namespace LeadScreenAssignment.Web.Controllers
{
    public class SubareasController : BaseController<SubAreaEntity, SubAreaModel,SubAreaEditModel>
    {
        public SubareasController(IService<SubAreaEntity, SubAreaModel, SubAreaEditModel> service) : base(service)
        {
        }
    }
}
