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
        public double? PH { get; set; }
        public string VisType { get; set; }
        public double? Brook1 { get; set; }
        public double? Brook5 { get; set; }
        public double? Brook10 { get; set; }
        public double? Brook20 { get; set; }
        public double? Brook30 { get; set; }
        public double? Brook40 { get; set; }
        public double? Brook50 { get; set; }
        public double? Brook60 { get; set; }
        public double? Brook70 { get; set; }
        public double? Brook80 { get; set; }
        public double? Brook90 { get; set; }
        public double? Brook100 { get; set; }
        public string BrookComment { get; set; }
        public string BrookDisc { get; set; }
        public double? BrookXVis { get; set; }
        public string BrookXRpm { get; set; }
        public string BrookXDisc { get; set; }
        public double? Krebs { get; set; }
        public string KrebsComment { get; set; }
        public double? Ici { get; set; }
        public string IciDisc { get; set; }
        public string IciComment { get; set; }
        public string Temp { get; set; }

        public virtual ExpLabBook ExpLabBook { get; set; }
    }
}
