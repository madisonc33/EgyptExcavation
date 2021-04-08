using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Excavation
    {
        public int ExcavationId { get; set; }
        public int? ExcYear { get; set; }
        public int? ExcMonth { get; set; }
        public int? ExcDayOfMonth { get; set; }
        public string FieldBook { get; set; }
        public int? FieldBookPageNum { get; set; }
        public string InitialsOfEntryExpert { get; set; }
        public string InitialsOfEntryChecker { get; set; }
        public byte[] Byusample { get; set; }
    }
}
