using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpLabBook
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Density { get; set; }
        public string Observation { get; set; }
        public string Remarks { get; set; }
        public long UserId { get; set; }
        public long? CycleId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool? Deleted { get; set; }

        public virtual User User { get; set; }
    }
}
