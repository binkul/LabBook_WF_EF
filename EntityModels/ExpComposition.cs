using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpComposition
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public int Ordering { get; set; }
        public string Component { get; set; }
        public bool? IsIntermediate { get; set; }
        public decimal Amount { get; set; }
        public int Operation { get; set; }
        public string Comment { get; set; }
    }
}
