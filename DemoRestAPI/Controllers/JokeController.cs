using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoBLL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoRestAPI.Controllers
{
    public class JokeController : Controller
    {
        private IBLLFacade _facade;
        public JokeController(IBLLFacade facade)
        {
            _facade = facade;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return Ok(_facade.JokeService.GetAll());
        }
    }
}
