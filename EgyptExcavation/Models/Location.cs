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
        [Key]
        public int LocId { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Required(ErrorMessage = "MetersNS is required")]
        public int? MetersNs { get; set; }
    
        [Required (ErrorMessage = "BurialNS is required")]
        public string? BurialNs { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Required(ErrorMessage = "MetersEW is required")]
        public int? MetersEw { get; set; }

        [Required(ErrorMessage = "BurialEW is required")]
        public string? BurialEw { get; set; }

        [Required(ErrorMessage = "Subplot is required")]
        public string? Subplot { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Required(ErrorMessage = "Hill area is required")]
        public int? HillArea { get; set; }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Required(ErrorMessage = "Tomb Num is required")]
        public int? TombNum { get; set; }
    }
}
