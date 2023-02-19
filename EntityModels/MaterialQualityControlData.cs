using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class MaterialQualityControlData
    {
        public long Id { get; set; }
        public long? ControlId { get; set; }
        public string Temperature { get; set; }
        public double? PH { get; set; }
        public double? Density { get; set; }
        public double? ViscosityA { get; set; }
        public string ViscosityASpeed { get; set; }
        public string ViscosityADisc { get; set; }
        public double? ViscosityB { get; set; }
        public string ViscosityBSpeed { get; set; }
        public string ViscosityBDisc { get; set; }
        public double? ViscosityC { get; set; }
        public string ViscosityCSpeed { get; set; }
        public string ViscosityCDisc { get; set; }
        public double? Solids { get; set; }
        public string Appearance { get; set; }
        public double? L { get; set; }
        public double? A { get; set; }
        public double? B { get; set; }
        public double? Wi { get; set; }
        public double? Yi { get; set; }
        public bool? Biology { get; set; }
        public string Inclusion { get; set; }
        public string Sieve { get; set; }
    }
}
