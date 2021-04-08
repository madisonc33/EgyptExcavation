using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Bone
    {
        public int BoneId { get; set; }
        public string EpiphysealUnion { get; set; }
        public int? ZygomaticCrest { get; set; }
        public int? NuchalCrest { get; set; }
        public int? Gonian { get; set; }
        public int? ParietalBossing { get; set; }
        public int? OrbitEdge { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? Robust { get; set; }
        public double? TibiaLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? FemerLength { get; set; }
        public double? Humerus { get; set; }
        public double? FemurDiameter { get; set; }
        public double? IliacCrest { get; set; }
        public double? MedialClavicle { get; set; }
        public double? BoneLength { get; set; }
        public string PubicSymphysis { get; set; }
        public string Osteophytosis { get; set; }
        public double? HumerusHead { get; set; }
        public double? FemurHead { get; set; }
        public double? ForemanMagnum { get; set; }
        public int? DorsalPitting { get; set; }
        public int? MedialIpRamus { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? PubicBone { get; set; }
        public int? SciaticNotch { get; set; }
        public int? SubpubicAngle { get; set; }
        public int? VentralArc { get; set; }
        public string BasilarSuture { get; set; }
        public bool? PostcrainiaAtMagazine { get; set; }
        public bool? PostcrainiaTrauma { get; set; }
        public string OsteologyNotes { get; set; }
    }
}
