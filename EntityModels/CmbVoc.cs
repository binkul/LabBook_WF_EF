using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbVoc
    {
        public long Id { get; set; }
        public string Voc { get; set; }
        public DateTime Date { get; set; }
    }
}
