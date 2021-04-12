﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Burial
    {
        public int? OrientationId { get; set; }
        [Key]
        public int BurialId { get; set; }
        public int? BurialNum { get; set; }
        public int? LocId { get; set; }
        public int? BodyId { get; set; }
        public int? ExcavationId { get; set; }
        public string? FaceBundleKey { get; set; }
        public bool? ArtifactFound { get; set; }
        public string? ArtifactsDescription { get; set; }
        public string? Cluster { get; set; }
        public string? Goods { get; set; }
        public string? BiologicalInitials { get; set; }
        public int? BiologicalClusterNum { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string? BiologicalNotes { get; set; }
        public bool? ToBeConfirmed { get; set; }
        public string? BurialSituation { get; set; }
    }
}
