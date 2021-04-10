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
using EgyptExcavation.Models.ViewModels;

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
            return View();
        }

        //idea for storing form
        //[HttpPost]
        //public IActionResult EnterBurial(Burial bur, Body bod)
        //{
        //    context.Body.Add(bod);
        //    context.Body.
        //    //get most recent body ID
        //    //add bodyID to bur
        //    context.Burial.Add(bur);

        //    return View();
        //}

        public IActionResult BurialList()
        {
            var mummy = new MummyInfo();
            foreach(var b in context.Burial)
            {
                
            }

            return View();
        }

        public IActionResult BurialDetails()
        {
            return View();
        }

        public IActionResult EditFieldNotes()
        {
            return View();
        }

        public IActionResult EditMummyInfo()
        {
            return View();
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
