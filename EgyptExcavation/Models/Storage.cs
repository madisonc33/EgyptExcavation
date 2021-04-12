using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Storage
    {
        [Key]
        public int RackId { get; set; }
        public int? SampleId { get; set; }
        public string RackNum { get; set; }
        public int? ShelfNum { get; set; }
        public int? TubeNum { get; set; }
        public int? BagNum { get; set; }
    }
}
