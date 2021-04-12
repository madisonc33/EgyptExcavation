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
using Microsoft.AspNetCore.Authorization;

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

        public IActionResult BurialList()
        {
            var mummies = new List<MummyInfo>();

            foreach (var b in context.Burial)
            {
                var mummy = new MummyInfo();

                mummy.burial = b;
                mummy.body = context.Body.Where(x => x.BodyId == b.BodyId).FirstOrDefault();
                mummy.bone = context.Bone.Where(x => x.BoneId == mummy.body.BoneId).FirstOrDefault();
                mummy.cranial = context.Cranial.Where(x => x.CranialId == mummy.body.CranialId).FirstOrDefault();
                mummy.excavation = context.Excavation.Where(x => x.ExcavationId == b.ExcavationId).FirstOrDefault();
                foreach (var f in context.Files)
                {
                    if (f.BurialId == b.BurialId)
                        mummy.files.Add(f);
                } 
                mummy.location = context.Location.Where(x => x.LocId == b.LocId).FirstOrDefault();
                mummy.physicalOrientation = context.PhysicalOrientation.Where(x => x.OrientationId == b.OrientationId).FirstOrDefault();
                foreach (Sample s in context.Sample)
                {
                    if (s.BodyId == mummy.body.BodyId)
                        mummy.sample.Add(s);
                }
                foreach (var s in context.Storage)
                {
                    foreach (var sam in mummy.sample)
                    {
                        if (s.SampleId == sam.SampleId)
                            mummy.storage.Add(s);
                    }
                }
                foreach (var t in context.Tooth)
                {
                    if (t.BodyId == mummy.body.BodyId)
                        mummy.tooth.Add(t);
                }

                mummies.Add(mummy);
            }

            return View(mummies);
        }

        [HttpPost]
        public IActionResult BurialDetails(int burialid)
        {
            var mummy = new MummyInfo();

            mummy.burial = context.Burial.Where(x => x.BurialId == burialid).FirstOrDefault();
            mummy.body = context.Body.Where(x => x.BodyId == mummy.burial.BodyId).FirstOrDefault();
            mummy.bone = context.Bone.Where(x => x.BoneId == mummy.body.BoneId).FirstOrDefault();
            mummy.cranial = context.Cranial.Where(x => x.CranialId == mummy.body.CranialId).FirstOrDefault();
            mummy.excavation = context.Excavation.Where(x => x.ExcavationId == mummy.burial.ExcavationId).FirstOrDefault();
            foreach (var f in context.Files)
            {
                if (f.BurialId == mummy.burial.BurialId)
                    mummy.files.Add(f);
            }
            mummy.location = context.Location.Where(x => x.LocId == mummy.burial.LocId).FirstOrDefault();
            mummy.physicalOrientation = context.PhysicalOrientation.Where(x => x.OrientationId == mummy.burial.OrientationId).FirstOrDefault();
            foreach (Sample s in context.Sample)
            {
                if (s.BodyId == mummy.body.BodyId)
                    mummy.sample.Add(s);
            }
            foreach (var s in context.Storage)
            {
                foreach (var sam in mummy.sample)
                {
                    if (s.SampleId == sam.SampleId)
                        mummy.storage.Add(s);
                }
            }
            foreach (var t in context.Tooth)
            {
                if (t.BodyId == mummy.body.BodyId)
                    mummy.tooth.Add(t);
            }

            return View(mummy);
        }

        //BURIAL

        [Authorize]
        [HttpGet]
        public IActionResult EnterFieldNotesBurial()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EnterFieldNotesBurial(Burial b)
        {
            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Burial.Add(b);
                context.SaveChanges();

                var mummies = new List<MummyInfo>();

                foreach (var i in context.Burial)
                {
                    var mummy = new MummyInfo();

                    mummy.burial = i;
                    mummy.body = context.Body.Where(x => x.BodyId == i.BodyId).FirstOrDefault();
                    mummy.bone = context.Bone.Where(x => x.BoneId == mummy.body.BoneId).FirstOrDefault();
                    mummy.cranial = context.Cranial.Where(x => x.CranialId == mummy.body.CranialId).FirstOrDefault();
                    mummy.excavation = context.Excavation.Where(x => x.ExcavationId == i.ExcavationId).FirstOrDefault();
                    foreach (var f in context.Files)
                    {
                        if (f.BurialId == b.BurialId)
                            mummy.files.Add(f);
                    }
                    mummy.location = context.Location.Where(x => x.LocId == i.LocId).FirstOrDefault();
                    mummy.physicalOrientation = context.PhysicalOrientation.Where(x => x.OrientationId == i.OrientationId).FirstOrDefault();
                    foreach (Sample s in context.Sample)
                    {
                        if (s.BodyId == mummy.body.BodyId)
                            mummy.sample.Add(s);
                    }
                    foreach (var s in context.Storage)
                    {
                        foreach (var sam in mummy.sample)
                        {
                            if (s.SampleId == sam.SampleId)
                                mummy.storage.Add(s);
                        }
                    }
                    foreach (var t in context.Tooth)
                    {
                        if (t.BodyId == mummy.body.BodyId)
                            mummy.tooth.Add(t);
                    }

                    mummies.Add(mummy);
                }
                return View("BurialList", mummies);
            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldNotesBurial(int BurialID)
        {
            Burial b = context.Burial.Single(x => x.BurialId == BurialID);
            return View("EditFieldNotesBurial", b);

        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldNotesBurial2(Burial b, int BurialID)
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

        //BODY
        [Authorize]
        [HttpGet]
        public IActionResult EnterFieldBody()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EnterFieldBody(Body b)
        {
            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Body.Add(b);
                context.SaveChanges();
                return View("BurialList", context.Body);
            }
            //Otherwise
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditFieldBody(int BodyID)
        {
            Body b = context.Body.Single(x => x.BodyId == BodyID);
            return View("EditFieldBody", b);

        }

        [Authorize]
        [HttpPost]
        public IActionResult EditFieldBody2(Body b, int BodyID)
        {
            if (ModelState.IsValid)
            {
                var bod = context.Body.SingleOrDefault(x => x.BodyId == b.BodyId);

                context.Entry(bod).Property(x => x.BurialPreservation).CurrentValue = b.BurialPreservation;
                context.Entry(bod).Property(x => x.PreservationIndex).CurrentValue = b.PreservationIndex;
                context.Entry(bod).Property(x => x.AgeAtDeath).CurrentValue = b.AgeAtDeath;
                context.Entry(bod).Property(x => x.SampleTaken).CurrentValue = b.SampleTaken;
                context.Entry(bod).Property(x => x.AgeMethod).CurrentValue = b.AgeMethod;
                context.Entry(bod).Property(x => x.GenderMethod).CurrentValue = b.GenderMethod;
                context.Entry(bod).Property(x => x.EstimateLivingStature).CurrentValue = b.EstimateLivingStature;
                context.Entry(bod).Property(x => x.HairTaken).CurrentValue = b.HairTaken;
                context.Entry(bod).Property(x => x.SoftTissueTaken).CurrentValue = b.SoftTissueTaken;
                context.Entry(bod).Property(x => x.BoneTaken).CurrentValue = b.BoneTaken;
                context.Entry(bod).Property(x => x.ToothTaken).CurrentValue = b.ToothTaken;
                context.Entry(bod).Property(x => x.TextileTaken).CurrentValue = b.TextileTaken;
                context.Entry(bod).Property(x => x.DescriptionOfTaken).CurrentValue = b.DescriptionOfTaken;
                context.Entry(bod).Property(x => x.SequenceDna).CurrentValue = b.SequenceDna;
                context.Entry(bod).Property(x => x.CarbonEstimatedDate).CurrentValue = b.CarbonEstimatedDate;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //EXCAVATION
        [Authorize]
        [HttpGet]
        public IActionResult EnterFieldExcavation()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EnterFieldExcavation(Excavation e)
        {
            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Excavation.Add(e);
                context.SaveChanges();
                return View("BurialList", context.Excavation);
            }
            //Otherwise
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditFieldExcavation(int ExcavationID)
        {
            Excavation e = context.Excavation.Single(x => x.ExcavationId == ExcavationID);
            return View("EditFieldExcavation", e);

        }

        [Authorize]
        [HttpPost]
        public IActionResult EditFieldExcavation2(Excavation e, int ExcavationID)
        {
            if (ModelState.IsValid)
            {
                var exc = context.Excavation.SingleOrDefault(x => x.ExcavationId == e.ExcavationId);

                context.Entry(exc).Property(x => x.ExcYear).CurrentValue = e.ExcYear;
                context.Entry(exc).Property(x => x.ExcMonth).CurrentValue = e.ExcMonth;
                context.Entry(exc).Property(x => x.ExcDayOfMonth).CurrentValue = e.ExcDayOfMonth;
                context.Entry(exc).Property(x => x.FieldBook).CurrentValue = e.FieldBook;
                context.Entry(exc).Property(x => x.FieldBookPageNum).CurrentValue = e.FieldBookPageNum;
                context.Entry(exc).Property(x => x.InitialsOfEntryExpert).CurrentValue = e.InitialsOfEntryExpert;
                context.Entry(exc).Property(x => x.InitialsOfEntryChecker).CurrentValue = e.InitialsOfEntryChecker;
                context.Entry(exc).Property(x => x.Byusample).CurrentValue = e.Byusample;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //SAMPLE
        [Authorize]
        [HttpGet]
        public IActionResult EnterSamples()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult EditSample(int SampleID)
        {
            Sample s = context.Sample.Single(x => x.SampleId == SampleID);
            return View("EditSample", s);

        }

        [Authorize]
        [HttpPost]
        public IActionResult EditSample2(Sample s, int SampleID)
        {
            if (ModelState.IsValid)
            {
                var sam = context.Sample.SingleOrDefault(x => x.SampleId == s.SampleId);

                context.Entry(sam).Property(x => x.MlSize).CurrentValue = s.MlSize;
                context.Entry(sam).Property(x => x.Description).CurrentValue = s.Description;
                context.Entry(sam).Property(x => x.Category).CurrentValue = s.Category;
                context.Entry(sam).Property(x => x.Notes).CurrentValue = s.Notes;
                context.Entry(sam).Property(x => x.HairTaken).CurrentValue = s.HairTaken;
                context.Entry(sam).Property(x => x.SoftTissueTaken).CurrentValue = s.SoftTissueTaken;
                context.Entry(sam).Property(x => x.BoneTaken).CurrentValue = s.BoneTaken;
                context.Entry(sam).Property(x => x.ToothTaken).CurrentValue = s.ToothTaken;
                context.Entry(sam).Property(x => x.TextileTaken).CurrentValue = s.TextileTaken;
                context.Entry(sam).Property(x => x.DescriptionOfTaken).CurrentValue = s.DescriptionOfTaken;
                context.Entry(sam).Property(x => x.SampleTaken).CurrentValue = s.SampleTaken;
                context.Entry(sam).Property(x => x.Foci).CurrentValue = s.Foci;
                context.Entry(sam).Property(x => x.C14sample2017).CurrentValue = s.C14sample2017;
                context.Entry(sam).Property(x => x.LocationDescription).CurrentValue = s.LocationDescription;
                context.Entry(sam).Property(x => x.Questions).CurrentValue = s.Questions;
                context.Entry(sam).Property(x => x.Conventional14CageBp).CurrentValue = s.Conventional14CageBp;
                context.Entry(sam).Property(x => x._14calDate).CurrentValue = s._14calDate;
                context.Entry(sam).Property(x => x.MaxCalibrated95PercCalDate).CurrentValue = s.MaxCalibrated95PercCalDate;
                context.Entry(sam).Property(x => x.MinCalibrated95PercCalDate).CurrentValue = s.MinCalibrated95PercCalDate;
                context.Entry(sam).Property(x => x.SpanCalibrated95PercCalDate).CurrentValue = s.SpanCalibrated95PercCalDate;
                context.Entry(sam).Property(x => x.AvgCalibrated95PercCalDate).CurrentValue = s.AvgCalibrated95PercCalDate;

            context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //LOCATION
        [Authorize]
        [HttpGet]
        public IActionResult EnterFieldLocation()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult EditFieldLocation(int LocID)
        {
            Location l = context.Location.Single(x => x.LocId == LocID);
            return View("EditFieldLocation", l);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditLocation2(Location l, int LocID)
        {
            if (ModelState.IsValid)
            {
                var loca = context.Location.SingleOrDefault(x => x.LocId == l.LocId);

                context.Entry(loca).Property(x => x.MetersNs).CurrentValue = l.MetersNs;
                context.Entry(loca).Property(x => x.BurialNs).CurrentValue = l.BurialNs;
                context.Entry(loca).Property(x => x.MetersEw).CurrentValue = l.MetersEw;
                context.Entry(loca).Property(x => x.BurialEw).CurrentValue = l.BurialEw;
                context.Entry(loca).Property(x => x.Subplot).CurrentValue = l.Subplot;
                context.Entry(loca).Property(x => x.HillArea).CurrentValue = l.HillArea;
                context.Entry(loca).Property(x => x.TombNum).CurrentValue = l.TombNum;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //PHYSICAL ORIENTATION
        [Authorize]
        [HttpGet]
        public IActionResult EnterOrientation()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
            public IActionResult EnterOrientation(PhysicalOrientation po)
            {
                //first check data to make sure it's good before passing to Model and DB
                if (ModelState.IsValid)
                {
                    //Update Database
                    context.PhysicalOrientation.Add(po);
                    context.SaveChanges();
                    return View("BurialList", context.PhysicalOrientation);
                }
                //Otherwise
                return View();
            }

        [Authorize]
        [HttpPost]
        public IActionResult EditPhysicalOrientation(int POID)
        {
            PhysicalOrientation po = context.PhysicalOrientation.Single(x => x.OrientationId == POID);
            return View("EditFieldLocation", po);

        }

        [Authorize]
        [HttpPost]
        public IActionResult EditOrientation2(PhysicalOrientation po, int POID)
        {
            if (ModelState.IsValid)
            {
                var ori = context.PhysicalOrientation.SingleOrDefault(x => x.OrientationId == po.OrientationId);

                context.Entry(ori).Property(x => x.WtoFeet).CurrentValue = po.WtoFeet;
                context.Entry(ori).Property(x => x.StoFeet).CurrentValue = po.StoFeet;
                context.Entry(ori).Property(x => x.WtoHead).CurrentValue = po.WtoHead;
                context.Entry(ori).Property(x => x.StoHead).CurrentValue = po.StoHead;
                context.Entry(ori).Property(x => x.HeadDirection).CurrentValue = po.HeadDirection;
                context.Entry(ori).Property(x => x.BurialDepth).CurrentValue = po.BurialDepth;
                context.Entry(ori).Property(x => x.LengthOfRemainsInMeters).CurrentValue = po.LengthOfRemainsInMeters;
                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //FILES

        [Authorize]
        [HttpGet]
        public IActionResult EnterFiles()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditFieldNotes()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditMummyInfo()
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
