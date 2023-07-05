
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

        public ExpNormResultTabs() { }

        public ExpNormResultTabs(long labBookId, long userId, int pageNumber, bool tabVisibility, string tabHeaderName)
        {
            LabBookId = labBookId;
            UserId = userId;
            PageNumber = pageNumber;
            TabVisibility = tabVisibility;
            TabHeaderName = tabHeaderName;
        }
    }
}
