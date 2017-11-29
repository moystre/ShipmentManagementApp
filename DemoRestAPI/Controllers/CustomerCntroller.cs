using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoBLL.Facade;
using Microsoft.Extensions.Configuration;
using BLL.BusinessObjects;
using Microsoft.AspNetCore.Cors;
using BLL;

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomerController : Controller
    {
        IBLLFacade bllFacade;
        public CustomerController(IBLLFacade facade) {
            this.bllFacade = facade;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerBO> Get()
        {
            return bllFacade.CustomerService.GetAll();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public CustomerBO Get(int id)
        {
            return bllFacade.CustomerService.Get(id);
        }
        
        // POST: api/Customer
        [HttpPost]
        public IActionResult Post([FromBody]CustomerBO customer)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }
            return Ok(bllFacade.CustomerService.Create(customer));
        }
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CustomerBO customer)
        {
            if (id != customer.Id)
            {
                return StatusCode(405, "Path Id does not match Customer Id.");
            }

            try
            {
                var _user = bllFacade.CustomerService.Update(customer);
                return Ok(_user);
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
                var customer = bllFacade.CustomerService.Delete(id);
                return Ok(customer);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
