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

        public IActionResult BurialDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterFieldNotes(Burial b)
        {
            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Burial.Add(b);
                context.SaveChanges();
                return View("BurialList", context.Burial);
            }
            //Otherwise
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

                context.Entry(bur).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
                context.Entry(bur).Property(x => x.ArtifactFound).CurrentValue = b.ArtifactFound;
                context.Entry(bur).Property(x => x.ArtifactsDescription).CurrentValue = b.ArtifactsDescription;
                context.Entry(bur).Property(x => x.Cluster).CurrentValue = b.Cluster;
                context.Entry(bur).Property(x => x.Goods).CurrentValue = b.Goods;
                context.Entry(bur).Property(x => x.BiologicalInitials).CurrentValue = b.BiologicalInitials;
                context.Entry(bur).Property(x => x.BiologicalClusterNum).CurrentValue = b.BiologicalClusterNum;
                context.Entry(bur).Property(x => x.PreviouslySampled).CurrentValue = b.PreviouslySampled;
                context.Entry(bur).Property(x => x.BiologicalNotes).CurrentValue = b.BiologicalNotes;
                context.Entry(bur).Property(x => x.ToBeConfirmed).CurrentValue = b.ToBeConfirmed;
                context.Entry(bur).Property(x => x.BurialSituation).CurrentValue = b.BurialSituation;


                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult RemoveFieldNotes(int BurialID)
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

//TEST 3. This is working?
