using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class PhysicalOrientation
    {
        [Key]
        public int OrientationId { get; set; }
        public double? WtoFeet { get; set; }
        public double? StoFeet { get; set; }
        public double? WtoHead { get; set; }
        public double? StoHead { get; set; }
        public string HeadDirection { get; set; }
        public double? BurialDepth { get; set; }
        public double? LengthOfRemainsInMeters { get; set; }
    }
}
