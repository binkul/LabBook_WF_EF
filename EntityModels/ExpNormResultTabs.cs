
namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpNormResultTabs
    {
        public long Id { get; set; }
        public long LabBookId { get; set; }
        public long UserId { get; set; }
        public int PageNumber { get; set; }
        public bool TabVisibility { get; set; } = false;
        public string TabHeaderName { get; set; }
    }
}
