namespace LabBook_WF_EF.EntityModels
{
    public class ExpViscosityFields
    {
        public long Id { get; set; }
        public long LabbookId { get; set; }
        public string Name { get; set; }
        public double? Width { get; set; }
        public long UserId { get; set; }
    }
}
