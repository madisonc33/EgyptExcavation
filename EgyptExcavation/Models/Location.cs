using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Location
    {
        public int LocId { get; set; }
      //  [Required]
        public int? MetersNs { get; set; }
     //   [Required]
        public string BurialNs { get; set; }
     //   [Required]
        public int? MetersEw { get; set; }
     //   [Required]
        public string BurialEw { get; set; }
        public string Subplot { get; set; }
        public int? HillArea { get; set; }
        public int? TombNum { get; set; }
    }
}
