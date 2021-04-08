using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Tooth
    {
        public int ToothId { get; set; }
        public int? BodyId { get; set; }
        public byte[] LinearHypoplasiaEnamel { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomoly { get; set; }
    }
}
