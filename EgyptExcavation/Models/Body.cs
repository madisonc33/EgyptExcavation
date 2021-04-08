﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Body
    {
        public int BodyId { get; set; }
        public string HairColorKey { get; set; }
        public string GenderKey { get; set; }
        public string AgeKey { get; set; }
        public string WrappingKey { get; set; }
        public string AdultChildKey { get; set; }
        public int? CranialId { get; set; }
        public int? BoneId { get; set; }
        public string BurialPreservation { get; set; }
        public string PreservationIndex { get; set; }
        public string AgeAtDeath { get; set; }
        public bool? SampleTaken { get; set; }
        public string AgeMethod { get; set; }
        public string GenderMethod { get; set; }
        public double? EstimateLivingStature { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string SequenceDna { get; set; }
        public int? CarbonEstimatedDate { get; set; }
        public int? YearAnalyzed { get; set; }
    }
}
