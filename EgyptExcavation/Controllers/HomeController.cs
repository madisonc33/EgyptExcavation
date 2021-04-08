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
        //Initalize and Bring in Context
        private egyptexcavationContext context { get; set; }

        private readonly ILogger<HomeController> _logger;
        //private egyptexcavationContext context { get; set; } , egyptexcavationContext con

        public HomeController(ILogger<HomeController> logger, egyptexcavationContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
           return View();
        }

        public IActionResult BurialList()
        {
            return View();
        }

        public IActionResult BurialDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult EditFieldNotes1(int BurialID)
        {
            Burial b = context.Burial.Single(x => x.BurialId == BurialID);
            return View("EditFieldNotes", b);

        }

        [HttpPost]
        public IActionResult EditFieldNotes2(Burial b, int BurialID)
        {
            if (ModelState.IsValid)
            {
                var bur = context.Burial.SingleOrDefault(x => x.BurialId == b.BurialId);

                context.Entry(bur).Property(x => x.quoteText).CurrentValue = q.quoteText;
                context.Entry(bur).Property(x => x.Author).CurrentValue = q.Author;
                context.Entry(bur).Property(x => x.quoteDate).CurrentValue = q.quoteDate;
                context.Entry(bur).Property(x => x.Subject).CurrentValue = q.Subject;
                context.Entry(bur).Property(x => x.Citation).CurrentValue = q.Citation;


                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }



        [HttpPost]
        public IActionResult Remove(int BurialID)
        {
            Burial b = context.Burial.Single(x => x.BurialId == BurialID);
            context.Remove(b);
            context.SaveChanges();
            return RedirectToAction("BurialList");
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

//TEST. IS THIS WORKING?

//TEST 2. This is working?
