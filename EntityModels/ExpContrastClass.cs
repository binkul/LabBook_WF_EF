namespace LabBook_WF_EF.EntityModels
{
    public class ExpContrastClass
    {
        private long _id;
        private long _labbookId;
        private long _class;
        private long _yield;

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

        public long Class
        {
            get => _class;
            set { _class = value; Modified = true; }
        }

        public long Yield
        {
            get => _yield;
            set { _yield = value; Modified = true; }
        }

    }
}
