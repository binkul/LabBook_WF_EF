using LabBook_WF_EF.Commons;

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbApplicator
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public virtual ObservableListSource<ExpContrast> ExpContrasts { get; set; }
        public virtual ObservableListSource<ExpGloss> ExpGlosses { get; set; }
    }
}
