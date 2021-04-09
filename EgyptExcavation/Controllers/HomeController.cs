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
        public IActionResult EnterFieldBurial(Burial b)
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
        public IActionResult EditFieldBurial1(int BurialID)
        {
            Burial b = context.Burial.Single(x => x.BurialId == BurialID);
            return View("EditFieldNotesBurial", b);

        }

        [HttpPost]
        public IActionResult EditFieldBurial2(Burial b, int BurialID)
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

        //EDIT AND CHANGE THESE TO FIT EACH MODEL//

            //BODY

            [HttpPost]
            public IActionResult EnterFieldBody(Burial b)
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
            public IActionResult EditFieldBody1(int BurialID)
            {
                Burial b = context.Burial.Single(x => x.BurialId == BurialID);
                return View("EditFieldBody", b);

            }

            [HttpPost]
            public IActionResult EditFieldBody2(Burial b, int BurialID)
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

            //EXCAVATION

            [HttpPost]
            public IActionResult EnterFieldExcavation(Excavation e)
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
            public IActionResult EditExcavate1(int ExcavationID)
            {
                Burial b = context.Burial.Single(x => x.BurialId == BurialID);
                return View("EditFieldBody", b);

            }

            [HttpPost]
            public IActionResult EditExcavate2(Excavation e, int ExcavationID)
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

            //SAMPLE

            [HttpPost]
            public IActionResult EnterSamples(Sample s)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Sample.Add(s);
                    context.SaveChanges();
                    return View("BurialList", context.Sample);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditSample1(int SampleID)
            {
                Sample s = context.Sample.Single(x => x.SampleId == SampleID);
                return View("EditFieldLocation", s);

            }

            [HttpPost]
            public IActionResult EditSample2(Sample s, int SampleID)
            {
                if (ModelState.IsValid)
                {
                    var sam = context.Sample.SingleOrDefault(x => x.SampleId == s.SampleId);

                    context.Entry(sam).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
                    context.Entry(sam).Property(x => x.ArtifactFound).CurrentValue = b.ArtifactFound;
                    context.Entry(sam).Property(x => x.ArtifactsDescription).CurrentValue = b.ArtifactsDescription;
                    context.Entry(sam).Property(x => x.Cluster).CurrentValue = b.Cluster;
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

        //LOCATION

        [HttpPost]
        public IActionResult EnterFieldLocation(Location l)
        {
            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Location.Add(l);
                context.SaveChanges();
                return View("BurialList", context.Location);
            }
            //Otherwise
            return View();
        }

        [HttpPost]
        public IActionResult EditLocation1(int LocID)
        {
            Location l = context.Location.Single(x => x.LocId == LocID);
            return View("EditFieldLocation", l);

        }

        [HttpPost]
        public IActionResult EditLocation2(Location l, int LocID)
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


        //PHYSICAL ORIENTATION

        [HttpPost]
            public IActionResult EnterOrientation(Location l)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Location.Add(l);
                    context.SaveChanges();
                    return View("BurialList", context.Location);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditOrientation1(int LocID)
            {
                Location l = context.Location.Single(x => x.LocId == LocID);
                return View("EditFieldLocation", l);

            }

            [HttpPost]
            public IActionResult EditOrientation2(Location l, int LocID)
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

            //FILES

            [HttpPost]
            public IActionResult EnterFiles(Files f)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Files.Add(f);
                    context.SaveChanges();
                    return View("BurialList", context.Files);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditFiles1(int FileID)
            {
                Files f = context.Files.Single(x => x.FileId == FileID);
                return View("EditFiles", f);

            }

            [HttpPost]
            public IActionResult EditFiles2(Files f, int FileID)
            {
                if (ModelState.IsValid)
                {
                    var fil = context.Files.SingleOrDefault(x => x.FileId == f.FileId);

                    context.Entry(fil).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
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

            //STORAGE

            [HttpPost]
            public IActionResult EnterStorage(Storage s)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Storage.Add(s);
                    context.SaveChanges();
                    return View("BurialList", context.Storage);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditStorage1(int RackID)
            {
                Storage s = context.Storage.Single(x => x.RackId == RackID);
                return View("EditStorage", s);

            }

            [HttpPost]
            public IActionResult EditStorage2(Storage s, int RackID)
            {
                if (ModelState.IsValid)
                {
                    var stor = context.Storage.SingleOrDefault(x => x.RackId == s.RackId);

                    context.Entry(stor).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
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

            //CRANIAL

            [HttpPost]
            public IActionResult EnterCranial(Cranial c)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Cranial.Add(c);
                    context.SaveChanges();
                    return View("BurialList", context.Cranial);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditCranial1(int CranialID)
            {
                Cranial c = context.Cranial.Single(x => x.CranialId == CranialID);
                return View("EditCranial", c);

            }

            [HttpPost]
            public IActionResult EditCranial2(Cranial c, int CranialID)
            {
                if (ModelState.IsValid)
                {
                    var cran = context.Cranial.SingleOrDefault(x => x.CranialId == c.CranialId);

                    context.Entry(cran).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
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

            //BONE

            [HttpPost]
            public IActionResult EnterBone(Bone b)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.Bone.Add(b);
                    context.SaveChanges();
                    return View("BurialList", context.Bone);
                }
                //Otherwise
                return View();
            }

            [HttpPost]
            public IActionResult EditBone1(int BoneID)
            {
                Bone b = context.Bone.Single(x => x.BoneId == BoneID);
                return View("EditBone", b);

            }

            [HttpPost]
            public IActionResult EditBone2(Bone b, int BoneID)
            {
                if (ModelState.IsValid)
                {
                    var bon = context.Bone.SingleOrDefault(x => x.BoneId == b.BoneId);

                    context.Entry(bon).Property(x => x.BurialNum).CurrentValue = b.BurialNum;
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


        //COMPLETE

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
