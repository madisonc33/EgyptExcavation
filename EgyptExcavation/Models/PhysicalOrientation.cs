using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class PhysicalOrientation
    {
        public int OrientationId { get; set; }
        public decimal? WtoFeet { get; set; }
        public decimal? StoFeet { get; set; }
        public decimal? WtoHead { get; set; }
        public decimal? StoHead { get; set; }
        public string HeadDirection { get; set; }
        public decimal? BurialDepth { get; set; }
        public decimal? LengthOfRemainsInMeters { get; set; }
    }
}
