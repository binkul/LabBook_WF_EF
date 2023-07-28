using System;

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbNormDetail
    {
        public long Id { get; set; }
        public long NormId { get; set; }
        public string Description { get; set; }
        public string Substrate { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual CmbNorm CmbNorm { get; set; }

    }
}
