using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpAshBurn
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public double? Solid { get; set; }
        public double? Ash450 { get; set; }
        public double? Ash900 { get; set; }
        public double? Organic { get; set; }
        public double? TitaniumDioxide { get; set; }
        public double? CalciumCarbonate { get; set; }
        public double? Others { get; set; }
        public int VocId { get; set; }
        public string VocContent { get; set; }
        public double? Crucible1 { get; set; }
        public double? Crucible2 { get; set; }
        public double? Crucible3 { get; set; }
        public double? Paint1 { get; set; }
        public double? Paint2 { get; set; }
        public double? Paint3 { get; set; }
        public double? Crucible1051 { get; set; }
        public double? Crucible1052 { get; set; }
        public double? Crucible1053 { get; set; }
        public double? Crucible4051 { get; set; }
        public double? Crucible4052 { get; set; }
        public double? Crucible4053 { get; set; }
        public double? Crucible9001 { get; set; }
        public double? Crucible9002 { get; set; }
        public double? Crucible9003 { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
