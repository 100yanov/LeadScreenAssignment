using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadScreenAssignment.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            return new ActionResult<object>(new { TestProperty = "TestValue" });
        }
    }
}
