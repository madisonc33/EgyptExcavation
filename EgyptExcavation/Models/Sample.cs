using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Sample
    {
        public int SampleId { get; set; }
        public int? BodyId { get; set; }
        public int? MlSize { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? SampleTaken { get; set; }
        public int? Foci { get; set; }
        public int? C14sample2017 { get; set; }
        public string LocationDescription { get; set; }
        public string Questions { get; set; }
        public int? Conventional14CageBp { get; set; }
        public int? _14calDate { get; set; }
        public int? MaxCalibrated95PercCalDate { get; set; }
        public int? MinCalibrated95PercCalDate { get; set; }
        public int? SpanCalibrated95PercCalDate { get; set; }
        public string AvgCalibrated95PercCalDate { get; set; }
    }
}
