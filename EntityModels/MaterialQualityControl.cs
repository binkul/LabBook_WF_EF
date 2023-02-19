using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class MaterialQualityControl
    {
        public long Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryNumber { get; set; }
        public long MaterialId { get; set; }
        public string QualityNumber { get; set; }
        public string Remarks { get; set; }
        public long LoginId { get; set; }
        public bool Accepted { get; set; }
    }
}
