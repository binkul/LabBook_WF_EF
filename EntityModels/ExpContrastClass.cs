namespace LabBook_WF_EF.EntityModels
{
    public class ExpContrastClass
    {
        public long Id { get; set; }
        public long LabBookId { get; set; }
        public long ClassId { get; set; }
        public long YieldId { get; set; }

        public virtual ExpLabBook ExpLabBook { get; set; }
        public virtual CmbContrastClass CmbContrastClass { get; set; }
        public virtual CmbContrastYield CmbContrastYield { get; set; }

    }
}
