namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpGlossClass
    {
        public long Id { get; set; }
        public long LabBookId { get; set; }
        public long ClassId { get; set; }

        public virtual ExpLabBook ExpLabBook { get; set; }
        public virtual CmbGlosClass CmbGlosClass { get; set; }
    }
}
