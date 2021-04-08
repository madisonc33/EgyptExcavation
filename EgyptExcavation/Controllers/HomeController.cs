using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EgyptExcavation.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace EgyptExcavation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private egyptexcavationContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, egyptexcavationContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            var person = context.MyStudd;
          

           return View(person);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
