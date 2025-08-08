using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpaAPI.Controller
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API SPA esta rodando!");
        }
    }
}