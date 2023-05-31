namespace LabBook_WF_EF.EntityModels
{
    public class ExpContrastClass
    {
        private long _id;
        private long _labbookId;
        private long _classId;
        private long _yieldId;

        public bool Modified { get; set; } = false;
        public bool Added { get; set; } = false;

        public long Id
        {
            get => _id;
            set { _id = value; Modified = true; }
        }

        public long LabBookId
        {
            get => _labbookId;
            set { _labbookId = value; Modified = true; }
        }

        public long ClassId
        {
            get => _classId;
            set { _classId = value; Modified = true; }
        }

        public long YieldId
        {
            get => _yieldId;
            set { _yieldId = value; Modified = true; }
        }

        public virtual ExpLabBook ExpLabBook { get; set; }
        public virtual CmbContrastClass CmbContrastClass { get; set; }
        public virtual CmbContrastYield CmbContrastYield { get; set; }

    }
}
