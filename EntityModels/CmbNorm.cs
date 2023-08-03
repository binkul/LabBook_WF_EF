using System;
using System.Collections.Generic;

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbNorm
    {
        public long Id { get; set; }
        public string Norm { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual IList<CmbNormDetail> CmbNormDetails { get; set; }
    }
}
