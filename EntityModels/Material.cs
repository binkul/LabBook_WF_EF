using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class Material
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsIntermediate { get; set; }
        public bool? IsDanger { get; set; }
        public bool? IsProduction { get; set; }
        public bool? IsObserved { get; set; }
        public bool? IsActive { get; set; }
        public long IntermediateNrD { get; set; }
        public long ClpSignalWordId { get; set; }
        public long ClpMsdsId { get; set; }
        public long FunctionId { get; set; }
        public decimal? Price { get; set; }
        public long CurrencyId { get; set; }
        public long UnitId { get; set; }
        public double? Density { get; set; }
        public double? Solids { get; set; }
        public double? Ash450 { get; set; }
        public decimal? Voc { get; set; }
        public string Remarks { get; set; }
        public long LoginId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
