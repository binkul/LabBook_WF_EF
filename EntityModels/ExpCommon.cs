using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpCommon
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public string ScrubIso11998 { get; set; }
        public long ScrubIso11998Class { get; set; }
        public string ScrubBrush { get; set; }
        public string DryingIso91171 { get; set; }
        public string DryingIso91173 { get; set; }
        public string YellowingIso7724 { get; set; }
        public string SchockIso6272 { get; set; }
        public string PersonIso2409 { get; set; }
        public string KoenigIso2409 { get; set; }
        public string ScratchIso62721 { get; set; }
        public string AdhesionIso2409 { get; set; }
        public string StainIso28124 { get; set; }
        public string WaterIso28122 { get; set; }
        public string SaltSprayIso9227 { get; set; }
        public string FlashRust { get; set; }
        public string UvTest { get; set; }
        public string Hardness { get; set; }
        public string FlowLimit { get; set; }
        public string Runoff { get; set; }
        public string Yield { get; set; }
        public string Other { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
