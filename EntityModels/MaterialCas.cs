using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class MaterialCas
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public string Cas { get; set; }
        public string We { get; set; }
        public int ClpSignalWordId { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
