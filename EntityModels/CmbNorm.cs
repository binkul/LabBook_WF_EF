using LabBook_WF_EF.Commons;
using System;

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbNorm
    {
        public long Id { get; set; }
        public string Norm { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ObservableListSource<CmbNormDetail> CmbNormDetails { get; set; }

    }
}
