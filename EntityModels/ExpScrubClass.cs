namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpScrubClass
    {
        public long Id { get; set; }
        public long LabBookId { get; set; }
        public long ClassId { get; set; }
        public string ScrubSponge { get; set; }
        public string ScrubBrush { get; set; }

        public virtual ExpLabBook ExpLabBook { get; set; }
        public virtual CmbScrubClass CmbScrubClass { get; set; }

    }
}
