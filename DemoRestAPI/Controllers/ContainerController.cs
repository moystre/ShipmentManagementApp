using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BLL.BusinessObjects;
using BLL;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Containers")]
    public class ContainerController : Controller
    {
        IBLLFacade bllFacade;
        public ContainerController(IBLLFacade facade)
        {
            this.bllFacade = facade;
        }

        // GET: api/Container
        [HttpGet]
        public IEnumerable<ContainerBO> Get()
        {
            return bllFacade.ContainerService.GetAll();
        }

        // GET: api/Container/5
        [HttpGet("{id}")]
        public ContainerBO Get(int id)
        {
            return bllFacade.ContainerService.Get(id);
        }
        
        // POST: api/Container
        [HttpPost]
        public IActionResult Post([FromBody]ContainerBO container)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }
            return Ok(bllFacade.ContainerService.Create(container));
        }
        
        // PUT: api/Container/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ContainerBO container)
        {
            if (id != container.Id)
            {
                return StatusCode(405, "Path Id does not match Container Id.");
            }

            try
            {
                var _container = bllFacade.ContainerService.Update(container);
                return Ok(_container);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var container = bllFacade.ContainerService.Delete(id);
                return Ok(container);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
