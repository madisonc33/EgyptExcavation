using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Cranial
    {
        public int CranialId { get; set; }
        public double? MaxCranialLength { get; set; }
        public bool? SkullTrauma { get; set; }
        public double? MaxCranialBreadth { get; set; }
        public double? BasionBergmaHeight { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsithanLength { get; set; }
        public double? BizgoymaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaxNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public int? YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public bool? CribraOrbitalia { get; set; }
        public bool? PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLoc { get; set; }
        public bool? MetopicSuture { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public bool? Tmjoa { get; set; }
        public int? DateOnSkull { get; set; }
        public string CranialSuture { get; set; }
        public string GenderKey { get; set; }
        public double? GefunctionTotal { get; set; }
    }
}
