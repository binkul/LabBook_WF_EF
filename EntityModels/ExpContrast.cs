using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpContrast
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public decimal? Contrast75 { get; set; }
        public decimal? Tw75 { get; set; }
        public decimal? Sp75 { get; set; }
        public decimal? Contrast100 { get; set; }
        public decimal? Tw100 { get; set; }
        public decimal? Sp100 { get; set; }
        public decimal? Contrast150 { get; set; }
        public decimal? Tw150 { get; set; }
        public decimal? Sp150 { get; set; }
        public decimal? Contrast240 { get; set; }
        public decimal? Tw240 { get; set; }
        public decimal? Sp240 { get; set; }
        public long OtherAType { get; set; }
        public decimal? OtherAContrast { get; set; }
        public long OtherBType { get; set; }
        public decimal? OtherBContrast { get; set; }
        public long ContrastClass { get; set; }
        public long ContrastYield { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
