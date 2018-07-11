using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Categories.Controllers
{
    public class DataController : Controller
    {
        [HttpGet("/search")]
        public IActionResult Search()
        {
            return View();
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet("/view")]
        public IActionResult View()
        {
            return View();
        }

        [HttpPost("/results")]
        public IActionResult Results()
        {
            return View();
        }
    }
}
