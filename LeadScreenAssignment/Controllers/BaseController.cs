using LeadScreenAssignment.Core.Entities;
using LeadScreenAssignment.Core.Interfaces;
using LeadScreenAssignment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadScreenAssignment.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<TEntity, TFilter, TModel, TEditModel> : Controller
        where TEntity : BaseEntity, new()
        where TModel : BaseModel, new()
        where TEditModel : BaseModel, new()
        where TFilter : class, IFilter


    {
        //TODO: add filtering for models
        private IService<TEntity, TFilter, TModel, TEditModel> service;

        public BaseController(IService<TEntity, TFilter, TModel, TEditModel> service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TModel>> Get([FromQuery]TFilter filter = null)//TODO: implement filters for all endpoints
        {
            return new(this.service.Get(filter));
        }
        [HttpGet("{id}")]
        public ActionResult<TModel> Get(Guid id)
        {
            return new(this.service.Get(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] TEditModel model)
        {
            this.service.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] TEditModel model)
        {
            this.service.Update(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.service.Delete(id);
        }
    }
}
