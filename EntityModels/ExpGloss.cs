using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpGloss
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public decimal? Gloss20 { get; set; }
        public decimal? Gloss60 { get; set; }
        public decimal? Gloss85 { get; set; }
        public long GlossClass { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
