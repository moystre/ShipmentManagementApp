using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DemoBLL.Facade;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Authorization;
using BLL;
using Microsoft.AspNetCore.Cors;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Users")]
    public class UserController : Controller
    {

        IBLLFacade bllFacade;
        public UserController(IBLLFacade facade)
        {
            this.bllFacade = facade;
        }

        // GET: api/User
        //[Authorize]
        [Authorize]
        [HttpGet]
        public IEnumerable<UserBO> Get()
        {
            return bllFacade.UserService.GetAll();
        }

        // GET: api/User/5
        [Authorize]
        [HttpGet("{id}")]
        public UserBO Get(int id)
        {
            return bllFacade.UserService.Get(id);
        }

        // POST: api/User
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody]UserBO user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }
            return Ok(bllFacade.UserService.Create(user));

        }

        // PUT: api/User/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserBO user)
        {
            if (id != user.Id)
            {
                return StatusCode(405, "Path Id does not match User Id.");
            }

            try
            {
                var _user = bllFacade.UserService.Update(user);
                return Ok(_user);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = bllFacade.UserService.Delete(id);
                return Ok(user);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
