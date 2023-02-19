using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class MaterialComposition
    {
        public long Id { get; set; }
        public long MaterialId { get; set; }
        public long MaterialCasId { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
