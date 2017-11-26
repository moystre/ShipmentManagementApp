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

namespace RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/Shipment")]
    public class ShipmentController : Controller
    {
        BLLFacade bllFacade = new BLLFacade(conf);
        private static IConfiguration conf;

        // GET: api/Shipment
        [HttpGet]
        public IEnumerable<ShipmentBO> Get()
        {
            return bllFacade.ShipmentService.GetAll();
        }

        // GET: api/Shipment/5
        [HttpGet("{id}")]
        public ShipmentBO Get(int id)
        {
            return bllFacade.ShipmentService.Get(id);
        }
        
        // POST: api/Shipment
        [HttpPost]
        public IActionResult Post([FromBody]ShipmentBO shipment)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(406, ModelState);
            }
            return Ok(bllFacade.ShipmentService.Create(shipment));
        }
        
        // PUT: api/Shipment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ShipmentBO shipment)
        {
            if (id != shipment.Id)
            {
                return StatusCode(405, "Path Id does not match Customer Id.");
            }

            try
            {
                var _user = bllFacade.ShipmentService.Update(shipment);
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
                var shipment = bllFacade.ShipmentService.Delete(id);
                return Ok(shipment);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
