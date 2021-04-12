using System;
using System.Collections.Generic;

namespace EgyptExcavation.Models.ViewModels
{
    public class MummyAndPage
    {
        public List<MummyInfo> Mummies { get; set; } = new List<MummyInfo>();
        public PageNumberingInfo PageInfo { get; set; }
    }
}
