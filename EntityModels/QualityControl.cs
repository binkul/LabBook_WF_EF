using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class QualityControl
    {
        public long Id { get; set; }
        public DateTime ProductionDate { get; set; }
        public int Number { get; set; }
        public string ProductName { get; set; }
        public long? LabbookId { get; set; }
        public string Remarks { get; set; }
        public string ActiveFields { get; set; }
        public string ProductIndex { get; set; }
        public long LoginId { get; set; }
        public long ProductTypeId { get; set; }
    }
}
