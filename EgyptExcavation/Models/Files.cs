using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Files
    {
        public int FileId { get; set; }
        public int? BurialId { get; set; }
        public string Photo { get; set; }
        public byte[] FieldNote { get; set; }
        public byte[] OtherNote { get; set; }
        public byte[] BoneBook { get; set; }
    }
}
