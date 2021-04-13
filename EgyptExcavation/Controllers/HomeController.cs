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

        //creates a variable to store how many items will be displayed on each page
        public int ItemsPerPage { get; set; }


        public HomeController(ILogger<HomeController> logger, egyptexcavationContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestImage()
        {
            return View();
        }

        public IActionResult EnterTablesMenuPage()
        {
            return View();
        }

        public IActionResult BurialList(string depth, string age, string haircolor, string headdirection, string artifacts, string gender, int pagenum = 1)
        {
            ItemsPerPage = 5;

            var mummies = new MummyAndPage();

            mummies.FilterCriteria.age = age;
            mummies.FilterCriteria.haircolor = haircolor;
            mummies.FilterCriteria.headdirection = headdirection;
            mummies.FilterCriteria.artifacts = artifacts;
            mummies.FilterCriteria.gender = gender;

            var burialList = new List<Burial>();

            //checks if any filtering criteria have been specified, if not, it gets the first five, if yes it gets all to start)
            if (depth == null && age == null && haircolor == null && headdirection == null && artifacts == null && gender == null)
            {
                mummies.PageInfo = new PageNumberingInfo
                {
                    PageSize = ItemsPerPage,

                    //gets number of total mummies
                    TotalMummies = context.Burial.Count(),
                    CurrentPage = pagenum

                };

                burialList = context.Burial
                    .Skip((pagenum - 1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    .ToList();
            }
            else
            {
                burialList = context.Burial.ToList();
            }

            //gets all the information from the database and ties it together
            foreach (var b in burialList)
            {
                var mummy = new MummyInfo();
                mummy.burial = b;
                mummy.body = context.Body.FirstOrDefault(x => x.BodyId == b.BodyId);
                
                if (mummy.body != null)
                {
                    mummy.bone = context.Bone.FirstOrDefault(x => x.BoneId == mummy.body.BoneId);
                    mummy.cranial = context.Cranial.FirstOrDefault(x => x.CranialId == mummy.body.CranialId);

                    foreach (Sample s in context.Sample)
                    {
                        if (s.BodyId == mummy.body.BodyId)
                            mummy.sample.Add(s);
                    }

                    foreach (var t in context.Tooth)
                    {
                        if (t.BodyId == mummy.body.BodyId)
                            mummy.tooth.Add(t);
                    }
                }
                
                mummy.excavation = context.Excavation.FirstOrDefault(x => x.ExcavationId == b.ExcavationId);
                foreach (var f in context.Files)
                {
                    if (f.BurialId == b.BurialId)
                        mummy.files.Add(f);
                }
                mummy.location = context.Location.FirstOrDefault(x => x.LocId == b.LocId);
                mummy.physicalOrientation = context.PhysicalOrientation.FirstOrDefault(x => x.OrientationId == b.OrientationId);
                
                foreach (var s in context.Storage)
                {
                    foreach (var sam in mummy.sample)
                    {
                        if (s.SampleId == sam.SampleId)
                            mummy.storage.Add(s);
                    }
                }
                
                mummies.Mummies.Add(mummy);
            }

            //Code to remove items that don't meet the specified criteria

            //if (depth != null)
            //{
            //    if (depth == "small")
            //    {
            //        mummies.Mummies.OrderBy(x => x.physicalOrientation.BurialDepth);
            //    }
            //    else if (depth == "big")
            //    {
            //        mummies.Mummies.OrderByDescending(x => x.physicalOrientation.BurialDepth);
            //    }
            //}
            if (age != null)
            {
                foreach (var m in mummies.Mummies.ToList())
                {
                    if (m.body != null)
                    {
                        if (m.body.AgeKey != age || m.body.AgeKey == null)
                        {
                            mummies.Mummies.Remove(m);
                        }
                    }
                    else
                    {
                        mummies.Mummies.Remove(m);
                    }
                    
                }
            }
            if (haircolor != null)
            {
                foreach (var m in mummies.Mummies.ToList())
                {
                    if (m.body != null)
                    {
                        if (m.body.HairColorKey != haircolor || m.body.HairColorKey == null)
                        {
                            mummies.Mummies.Remove(m);
                        }
                    }
                    else
                    {
                        mummies.Mummies.Remove(m);
                    }
                   
                }
            }
            if (headdirection != null)
            {
                foreach (var m in mummies.Mummies.ToList())
                {
                    if (m.physicalOrientation != null)
                    {
                        if (m.physicalOrientation.HeadDirection != headdirection || m.physicalOrientation.HeadDirection == null)
                            {
                                mummies.Mummies.Remove(m);
                            }
                    }
                    else
                    {
                        mummies.Mummies.Remove(m);
                    }
                    
                }
            }
            if (artifacts != null)
            {
                foreach (var m in mummies.Mummies.ToList())
                {
                    if (m.burial != null)
                    {
                        bool artifactsBool = bool.Parse(artifacts);
                        if (m.burial.ArtifactFound == null || m.burial.ArtifactFound != artifactsBool)
                        {
                            mummies.Mummies.Remove(m);
                        }
                    }
                    else
                    {
                        mummies.Mummies.Remove(m);
                    }
                   
                    
                }
            }
            if (gender != null)
            {
                foreach (var m in mummies.Mummies.ToList())
                {
                    if (m.body != null)
                    {
                        if (m.body.GenderKey != gender || m.body.GenderKey == null)
                        {
                            mummies.Mummies.Remove(m);
                        }
                    }
                    else
                    {
                        mummies.Mummies.Remove(m);
                    }
                   
                }
            }

            
            //if we filtered, it resets the pagination so that it shows correctly
            if (depth != null || age != null || haircolor != null || headdirection != null || artifacts != null || gender != null)
            {
                mummies.PageInfo = new PageNumberingInfo
                {
                    PageSize = ItemsPerPage,

                    //gets number of total mummies
                    TotalMummies = mummies.Mummies.Count,
                    CurrentPage = pagenum

                };

                mummies.Mummies = mummies.Mummies.Skip((pagenum - 1) * ItemsPerPage)
                    .Take(ItemsPerPage)
                    .ToList();
            }

            //returns the few along with the list of mummies and the pagination information
            return View("BurialList", mummies);
        }

        [HttpPost]
        public IActionResult BurialDetails(int burialid)
        {
            //gets all the details for a specifc burial from the database
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

        //LOCATION
        //[Authorize]
        [HttpGet]
        public IActionResult EnterFieldLocation()
        {
            return View();
        }

        // [Authorize]
        [HttpPost]
        public IActionResult EnterFieldLocation(Location l)
        {
            var locid = context.Location.Skip(context.Location.Count() - 1).Take(1).FirstOrDefault().LocId;
            locid++;
            l.LocId = locid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Location.Add(l);
                context.SaveChanges();
                ViewBag.LocationId = l.LocId;
                return View("EnterFieldNotesBurial");
            }
            //Otherwise
            return View("EnterFieldLocation");
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldLocation(int LocID)
        {
            Location l = context.Location.Single(x => x.LocId == LocID);
            return View("EditFieldLocation", l);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldLocation2(Location l, int LocID)
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

        //BURIAL

        //[Authorize]
        [HttpGet]
        public IActionResult EnterFieldNotesBurial()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EnterFieldNotesBurial(Burial bu)
        {
            var burid = context.Burial.Skip(context.Burial.Count() - 1).Take(1).FirstOrDefault().BurialId;
            burid++;
            bu.BurialId = burid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                bu.LocId = ViewBag.LocationId;
                //Update Database
                context.Burial.Add(bu);
                context.SaveChanges();
                ViewBag.LocationId = null;
                ViewBag.OrientId = bu.OrientationId;
                ViewBag.BodId = bu.BodyId;
                return View("EnterPhysicalOrientation");
            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldNotesBurial(int BurialID)
        {
            Burial bu = context.Burial.Single(x => x.BurialId == BurialID);
            return View("EditFieldNotesBurial", bu);

        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldNotesBurial2(Burial bu, int BurialID)
        {
            if (ModelState.IsValid)
            {
                var bur = context.Burial.SingleOrDefault(x => x.BurialId == bu.BurialId);

                context.Entry(bur).Property(x => x.BurialNum).CurrentValue = bu.BurialNum;
                context.Entry(bur).Property(x => x.ArtifactFound).CurrentValue = bu.ArtifactFound;
                context.Entry(bur).Property(x => x.ArtifactsDescription).CurrentValue = bu.ArtifactsDescription;
                context.Entry(bur).Property(x => x.Cluster).CurrentValue = bu.Cluster;
                context.Entry(bur).Property(x => x.Goods).CurrentValue = bu.Goods;
                context.Entry(bur).Property(x => x.BiologicalInitials).CurrentValue = bu.BiologicalInitials;
                context.Entry(bur).Property(x => x.BiologicalClusterNum).CurrentValue = bu.BiologicalClusterNum;
                context.Entry(bur).Property(x => x.PreviouslySampled).CurrentValue = bu.PreviouslySampled;
                context.Entry(bur).Property(x => x.BiologicalNotes).CurrentValue = bu.BiologicalNotes;
                context.Entry(bur).Property(x => x.ToBeConfirmed).CurrentValue = bu.ToBeConfirmed;
                context.Entry(bur).Property(x => x.BurialSituation).CurrentValue = bu.BurialSituation;


                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //PHYSICAL ORIENTATION
        //[Authorize]
        [HttpGet]
        public IActionResult EnterPhysicalOrientation()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EnterPhysicalOrientation(PhysicalOrientation po)
        {
            var oriid = context.PhysicalOrientation.Skip(context.PhysicalOrientation.Count() - 1).Take(1).FirstOrDefault().OrientationId;
            oriid++;
            po.OrientationId = oriid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                po.OrientationId = ViewBag.OrientId;
                //Update Database
                context.PhysicalOrientation.Add(po);
                context.SaveChanges();
                ViewBag.OrientId = null;

                return View("EnterFieldBody");

            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditPhysicalOrientation(int POID)
        {
            PhysicalOrientation po = context.PhysicalOrientation.Single(x => x.OrientationId == POID);
            return View("EditFieldLocation", po);

        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditPhysicalOrientation2(PhysicalOrientation po, int POID)
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
        //[Authorize]
        [HttpGet]
        public IActionResult EnterFiles(int BurialId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterFiles()
        {
            /*var filid = context.Files.Skip(context.Location.Count() - 1).Take(1).FirstOrDefault().FileId;
            filid++;
            f.FileId = filid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Files.Add(f);
                context.SaveChanges();
                // return View("BurialList", context.Files);
                return View("EnterTablesMenuPage");
            } */
            //Otherwise
            return View("EnterTablesMenuPage"); 
        }

        [HttpPost]
        public IActionResult EditFiles(int FileID)
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

                context.Entry(fil).Property(x => x.BurialId).CurrentValue = fil.BurialId;
                context.Entry(fil).Property(x => x.Photo).CurrentValue = fil.Photo;
                context.Entry(fil).Property(x => x.FieldNote).CurrentValue = fil.OtherNote;
                context.Entry(fil).Property(x => x.BoneBook).CurrentValue = fil.BoneBook;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //BODY
        //[Authorize]
        [HttpGet]
        public IActionResult EnterFieldBody()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EnterFieldBody(Body bo)
        {
            var bodid = context.Body.Skip(context.Body.Count() - 1).Take(1).FirstOrDefault().BodyId;
            bodid++;
            bo.BodyId = bodid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                bo.BodyId = ViewBag.BodId;
                //Update Database
                context.Body.Add(bo);
                context.SaveChanges();
                ViewBag.BodId = null;
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldBody(int BodyID)
        {
            Body bo = context.Body.Single(x => x.BodyId == BodyID);
            return View("EditFieldBody", bo);

        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldBody2(Body bo, int BodyID)
        {
            if (ModelState.IsValid)
            {
                var bod = context.Body.SingleOrDefault(x => x.BodyId == bo.BodyId);

                context.Entry(bod).Property(x => x.BurialPreservation).CurrentValue = bo.BurialPreservation;
                context.Entry(bod).Property(x => x.PreservationIndex).CurrentValue = bo.PreservationIndex;
                context.Entry(bod).Property(x => x.AgeAtDeath).CurrentValue = bo.AgeAtDeath;
                context.Entry(bod).Property(x => x.SampleTaken).CurrentValue = bo.SampleTaken;
                context.Entry(bod).Property(x => x.AgeMethod).CurrentValue = bo.AgeMethod;
                context.Entry(bod).Property(x => x.GenderMethod).CurrentValue = bo.GenderMethod;
                context.Entry(bod).Property(x => x.EstimateLivingStature).CurrentValue = bo.EstimateLivingStature;
                context.Entry(bod).Property(x => x.SequenceDna).CurrentValue = bo.SequenceDna;
                context.Entry(bod).Property(x => x.CarbonEstimatedDate).CurrentValue = bo.CarbonEstimatedDate;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //TEETH

        [HttpGet]
        public IActionResult EnterTeeth(int BodyId)
        {
            return View();
        }


        [HttpPost]
        public IActionResult EnterTeeth(Tooth t)
        {
            var teeid = context.Tooth.Skip(context.Tooth.Count() - 1).Take(1).FirstOrDefault().ToothId;
            teeid++;
            t.ToothId = teeid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Tooth.Add(t);
                context.SaveChanges();
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        [HttpPost]
        public IActionResult EditTeeth(int ToothID)
        {
            Tooth t = context.Tooth.Single(x => x.ToothId == ToothID);
            return View("EditTeeth", t);

        }

        [HttpPost]
        public IActionResult EditTeeth2(Tooth t, int ToothID)
        {
            if (ModelState.IsValid)
            {
                var tee = context.Tooth.SingleOrDefault(x => x.ToothId == t.ToothId);

                context.Entry(tee).Property(x => x.BodyId).CurrentValue = t.BodyId;
                context.Entry(tee).Property(x => x.LinearHypoplasiaEnamel).CurrentValue = t.LinearHypoplasiaEnamel;
                context.Entry(tee).Property(x => x.ToothAttrition).CurrentValue = t.ToothAttrition;
                context.Entry(tee).Property(x => x.ToothEruption).CurrentValue = t.ToothEruption;
                context.Entry(tee).Property(x => x.PathologyAnomoly).CurrentValue = t.PathologyAnomoly;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //CRANIAL

        [HttpGet]
        public IActionResult EnterCranial(int CranialId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterCranial(Cranial c)
        {
            var craid = context.Cranial.Skip(context.Cranial.Count() - 1).Take(1).FirstOrDefault().CranialId;
            craid++;
            c.CranialId = craid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Cranial.Add(c);
                context.SaveChanges();
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        [HttpPost]
        public IActionResult EditCranial(int CranialID)
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

                context.Entry(cran).Property(x => x.MaxCranialLength).CurrentValue = c.MaxCranialLength;
                context.Entry(cran).Property(x => x.SkullTrauma).CurrentValue = c.SkullTrauma;
                context.Entry(cran).Property(x => x.MaxCranialBreadth).CurrentValue = c.MaxCranialBreadth;
                context.Entry(cran).Property(x => x.BasionBergmaHeight).CurrentValue = c.BasionBergmaHeight;
                context.Entry(cran).Property(x => x.BasionNasion).CurrentValue = c.BasionNasion;
                context.Entry(cran).Property(x => x.BasionProsithanLength).CurrentValue = c.BasionProsithanLength;
                context.Entry(cran).Property(x => x.BizgoymaticDiameter).CurrentValue = c.BizgoymaticDiameter;
                context.Entry(cran).Property(x => x.NasionProsthion).CurrentValue = c.NasionProsthion;
                context.Entry(cran).Property(x => x.MaxNasalBreadth).CurrentValue = c.MaxNasalBreadth;
                context.Entry(cran).Property(x => x.InterorbitalBreadth).CurrentValue = c.InterorbitalBreadth;
                context.Entry(cran).Property(x => x.YearOnSkull).CurrentValue = c.YearOnSkull;
                context.Entry(cran).Property(x => x.MonthOnSkull).CurrentValue = c.MonthOnSkull;
                context.Entry(cran).Property(x => x.SkullAtMagazine).CurrentValue = c.SkullAtMagazine;
                context.Entry(cran).Property(x => x.CribraOrbitalia).CurrentValue = c.CribraOrbitalia;
                context.Entry(cran).Property(x => x.PoroticHyperostosis).CurrentValue = c.PoroticHyperostosis;
                context.Entry(cran).Property(x => x.PoroticHyperostosisLoc).CurrentValue = c.PoroticHyperostosisLoc;
                context.Entry(cran).Property(x => x.MetopicSuture).CurrentValue = c.MetopicSuture;
                context.Entry(cran).Property(x => x.ButtonOsteoma).CurrentValue = c.ButtonOsteoma;
                context.Entry(cran).Property(x => x.OsteologyUnknownComment).CurrentValue = c.OsteologyUnknownComment;
                context.Entry(cran).Property(x => x.Tmjoa).CurrentValue = c.Tmjoa;
                context.Entry(cran).Property(x => x.CranialSuture).CurrentValue = c.CranialSuture;
                context.Entry(cran).Property(x => x.GefunctionTotal).CurrentValue = c.GefunctionTotal;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //BONE
        [HttpGet]
        public IActionResult EnterBone(int BoneId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterBone(Bone b)
        {
            var bonid = context.Bone.Skip(context.Bone.Count() - 1).Take(1).FirstOrDefault().BoneId;
            bonid++;
            b.BoneId = bonid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Bone.Add(b);
                context.SaveChanges();
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        [HttpPost]
        public IActionResult EditBone(int BoneID)
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

                context.Entry(bon).Property(x => x.EpiphysealUnion).CurrentValue = b.EpiphysealUnion;
                context.Entry(bon).Property(x => x.ZygomaticCrest).CurrentValue = b.ZygomaticCrest;
                context.Entry(bon).Property(x => x.NuchalCrest).CurrentValue = b.NuchalCrest;
                context.Entry(bon).Property(x => x.Gonian).CurrentValue = b.Gonian;
                context.Entry(bon).Property(x => x.ParietalBossing).CurrentValue = b.ParietalBossing;
                context.Entry(bon).Property(x => x.OrbitEdge).CurrentValue = b.OrbitEdge;
                context.Entry(bon).Property(x => x.SupraorbitalRidges).CurrentValue = b.SupraorbitalRidges;
                context.Entry(bon).Property(x => x.Robust).CurrentValue = b.Robust;
                context.Entry(bon).Property(x => x.TibiaLength).CurrentValue = b.TibiaLength;
                context.Entry(bon).Property(x => x.HumerusLength).CurrentValue = b.HumerusLength;
                context.Entry(bon).Property(x => x.Humerus).CurrentValue = b.Humerus;
                context.Entry(bon).Property(x => x.FemurDiameter).CurrentValue = b.FemurDiameter;
                context.Entry(bon).Property(x => x.IliacCrest).CurrentValue = b.IliacCrest;
                context.Entry(bon).Property(x => x.MedialClavicle).CurrentValue = b.MedialClavicle;
                context.Entry(bon).Property(x => x.BoneLength).CurrentValue = b.BoneLength;
                context.Entry(bon).Property(x => x.PubicSymphysis).CurrentValue = b.PubicSymphysis;
                context.Entry(bon).Property(x => x.Osteophytosis).CurrentValue = b.Osteophytosis;
                context.Entry(bon).Property(x => x.HumerusHead).CurrentValue = b.HumerusHead;
                context.Entry(bon).Property(x => x.FemurHead).CurrentValue = b.FemurHead;
                context.Entry(bon).Property(x => x.ForemanMagnum).CurrentValue = b.ForemanMagnum;
                context.Entry(bon).Property(x => x.DorsalPitting).CurrentValue = b.DorsalPitting;
                context.Entry(bon).Property(x => x.MedialIpRamus).CurrentValue = b.MedialIpRamus;
                context.Entry(bon).Property(x => x.PreaurSulcus).CurrentValue = b.PreaurSulcus;
                context.Entry(bon).Property(x => x.PubicBone).CurrentValue = b.PubicBone;
                context.Entry(bon).Property(x => x.SciaticNotch).CurrentValue = b.SciaticNotch;
                context.Entry(bon).Property(x => x.SubpubicAngle).CurrentValue = b.SubpubicAngle;
                context.Entry(bon).Property(x => x.VentralArc).CurrentValue = b.VentralArc;
                context.Entry(bon).Property(x => x.BasilarSuture).CurrentValue = b.BasilarSuture;
                context.Entry(bon).Property(x => x.PostcrainiaAtMagazine).CurrentValue = b.PostcrainiaAtMagazine;
                context.Entry(bon).Property(x => x.PostcrainiaTrauma).CurrentValue = b.PostcrainiaTrauma;
                context.Entry(bon).Property(x => x.OsteologyNotes).CurrentValue = b.OsteologyNotes;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //SAMPLE
        //[Authorize]
        [HttpGet]
        public IActionResult EnterSample(int BodyId)
        {
            return View("EnterStorage");
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EnterSample(Sample s)
        {
            var samid = context.Sample.Skip(context.Sample.Count() - 1).Take(1).FirstOrDefault().SampleId;
            samid++;
            s.SampleId = samid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Sample.Add(s);
                context.SaveChanges();
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditSample(int SampleID)
        {
            Sample s = context.Sample.Single(x => x.SampleId == SampleID);
            return View("EditSample", s);

        }

        //[Authorize]
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

        //STORAGE

        [HttpGet]
        public IActionResult EnterStorage(int SampleId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterStorage(Storage s)
        {
            var stoid = context.Storage.Skip(context.Storage.Count() - 1).Take(1).FirstOrDefault().RackId;
            stoid++;
            s.RackId = stoid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Storage.Add(s);
                context.SaveChanges();
                // return View("EnterPhysicalOrientation", context.Storage);
                return View("EnterTablesMenuPage");

            }
            //Otherwise
            return View();
        }

        [HttpPost]
        public IActionResult EditStorage(int RackID)
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

                context.Entry(stor).Property(x => x.SampleId).CurrentValue = s.SampleId;
                context.Entry(stor).Property(x => x.RackNum).CurrentValue = s.RackNum;
                context.Entry(stor).Property(x => x.ShelfNum).CurrentValue = s.ShelfNum;
                context.Entry(stor).Property(x => x.TubeNum).CurrentValue = s.TubeNum;
                context.Entry(stor).Property(x => x.BagNum).CurrentValue = s.BagNum;

                context.SaveChanges();

                return RedirectToAction("BurialList");
            }
            else
                return View();
        }

        //EXCAVATION
        //[Authorize]
        [HttpGet]
        public IActionResult EnterFieldExcavation(int ExcavationId)
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EnterFieldExcavation(Excavation e)
        {
            var exeid = context.Excavation.Skip(context.Excavation.Count() - 1).Take(1).FirstOrDefault().ExcavationId;
            exeid++;
            e.ExcavationId = exeid;

            //first check data to make sure it's good before passing to Model and DB
            if (ModelState.IsValid)
            {
                //Update Database
                context.Excavation.Add(e);
                context.SaveChanges();
                return View("EnterTablesMenuPage");
            }
            //Otherwise
            return View();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult EditFieldExcavation(int ExcavationID)
        {
            Excavation e = context.Excavation.Single(x => x.ExcavationId == ExcavationID);
            return View("EditFieldExcavation", e);

        }

        //[Authorize]
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

        [Authorize]
        public IActionResult EditFieldNotes()
        {
            return View();
        }

        //[Authorize(Roles = "Researcher")]
        public IActionResult EditMummyInfo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //not really used
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RecordDeleted(int burialId)
        {
            return View(burialId);
        }

        //DELETE STUFFFF
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteEntireBurial(int burialId)
        {
            //delete all the tables associated with this burial

            return RedirectToAction("BurialList");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldBody(int burialId, int BodyId)
        {
            //delete row in this table
            var body = context.Body.FirstOrDefault(x => x.BodyId == BodyId);
            context.Body.Remove(body);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldCranial(int burialId, int cranialId)
        {
            //delete row in this table
            var cranialDelete = context.Cranial.FirstOrDefault(x => x.CranialId == cranialId);
            context.Cranial.Remove(cranialDelete);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldBone(int burialId, int boneId)
        {
            //delete row in this table
            var bone = context.Bone.FirstOrDefault(x => x.BoneId == boneId);
            context.Bone.Remove(bone);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldTooth(int burialId, int ToothId)
        {
            //delete row in this table
            var tooth = context.Tooth.FirstOrDefault(x => x.ToothId == ToothId);
            context.Tooth.Remove(tooth);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldExcavation(int burialId, int ExcavationId)
        {
            //delete row in this table
            var excavation = context.Excavation.FirstOrDefault(x => x.ExcavationId == ExcavationId);
            context.Excavation.Remove(excavation);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldFile(int burialId, int fileId)
        {
            //delete row in this table
            var file = context.Files.FirstOrDefault(x => x.FileId == fileId);
            context.Files.Remove(file);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldSample(int burialId, int sampleId)
        {
            //delete row in this table
            var sample = context.Sample.FirstOrDefault(x => x.SampleId == sampleId);
            context.Sample.Remove(sample);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteFieldStorage(int burialId, int rackId)
        {
            //delete row in this table
            var rack = context.Storage.FirstOrDefault(x => x.RackId == rackId);
            context.Storage.Remove(rack);
            context.SaveChanges();

            return View("RecordDeleted", burialId);
        }

    }
}


