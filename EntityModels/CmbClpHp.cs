using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbClpHp
    {
        public long Id { get; set; }
        public string Class { get; set; }
        public string Clp { get; set; }
        public string Description { get; set; }
        public int Ordering { get; set; }
        public bool? IsH { get; set; }
        public DateTime DateCreated { get; set; }
        public long GhsId { get; set; }
        public long SignalId { get; set; }
    }
}
