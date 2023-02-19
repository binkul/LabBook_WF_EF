using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpSpectro
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public decimal? LM { get; set; }
        public decimal? AM { get; set; }
        public decimal? BM { get; set; }
        public decimal? WiM { get; set; }
        public decimal? YiM { get; set; }
        public decimal? LS { get; set; }
        public decimal? AS { get; set; }
        public decimal? BS { get; set; }
        public decimal? WiS { get; set; }
        public decimal? YiS { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public decimal? Z { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
