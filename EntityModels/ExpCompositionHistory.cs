using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpCompositionHistory
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public int Version { get; set; }
        public decimal Mass { get; set; }
        public string Comment { get; set; }
        public int LoginId { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
