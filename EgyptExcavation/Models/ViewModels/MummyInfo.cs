using System;
using System.Collections.Generic;

namespace EgyptExcavation.Models.ViewModels
{
    public class MummyInfo
    {
        public Burial burial { get; set; }

        public Body body { get; set; }

        public Bone bone { get; set; }

        public Cranial cranial { get; set; }

        public Excavation excavation { get; set; }

        public List<Files> files { get; set; } = new List<Files>();

        public Location location { get; set; }

        public PhysicalOrientation physicalOrientation { get; set; }

        public List<Sample> sample { get; set; } = new List<Sample>();

        public List<Storage> storage { get; set; } = new List<Storage>();

        public List<Tooth> tooth { get; set; } = new List<Tooth>();
    }
}
