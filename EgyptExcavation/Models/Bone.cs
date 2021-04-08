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
        public decimal? TibiaLength { get; set; }
        public decimal? HumerusLength { get; set; }
        public decimal? FemerLength { get; set; }
        public decimal? Humerus { get; set; }
        public decimal? FemurDiameter { get; set; }
        public decimal? IliacCrest { get; set; }
        public decimal? MedialClavicle { get; set; }
        public decimal? BoneLength { get; set; }
        public string PubicSymphysis { get; set; }
        public string Osteophytosis { get; set; }
        public decimal? HumerusHead { get; set; }
        public decimal? FemurHead { get; set; }
        public decimal? ForemanMagnum { get; set; }
        public int? DorsalPitting { get; set; }
        public int? MedialIpRamus { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? PubicBone { get; set; }
        public int? SciaticNotch { get; set; }
        public int? SubpubicAngle { get; set; }
        public int? VentralArc { get; set; }
        public string BasilarSuture { get; set; }
        public byte[] PostcrainiaAtMagazine { get; set; }
        public byte[] PostcrainiaTrauma { get; set; }
        public string OsteologyNotes { get; set; }
    }
}
