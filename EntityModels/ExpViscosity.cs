using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpViscosity
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public decimal? PH { get; set; }
        public string VisType { get; set; }
        public decimal? Brook1 { get; set; }
        public decimal? Brook5 { get; set; }
        public decimal? Brook10 { get; set; }
        public decimal? Brook20 { get; set; }
        public decimal? Brook30 { get; set; }
        public decimal? Brook40 { get; set; }
        public decimal? Brook50 { get; set; }
        public decimal? Brook60 { get; set; }
        public decimal? Brook70 { get; set; }
        public decimal? Brook80 { get; set; }
        public decimal? Brook90 { get; set; }
        public decimal? Brook100 { get; set; }
        public string BrookComment { get; set; }
        public string BrookDisc { get; set; }
        public decimal? BrookXVis { get; set; }
        public string BrookXRpm { get; set; }
        public string BrookXDisc { get; set; }
        public decimal? Krebs { get; set; }
        public string KrebsComment { get; set; }
        public decimal? Ici { get; set; }
        public string IciDisc { get; set; }
        public string IciComment { get; set; }
        public string Temp { get; set; }

        public virtual ExpLabBook ExpLabBook { get; set; }
    }
}
