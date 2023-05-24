using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpContrast
    {
        private long _id;
        private long _labbookId;
        private long _applicatiorId;
        private int _position;
        private double? _contrast;
        private double? _tw;
        private double? _sp;
        private string _comments;
        public DateTime DateCreated { get; set; }
        private DateTime _dateUpdated;

        public virtual CmbApplicator Applicator { get; set; }


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

        public long ApplicatiorId
        {
            get => _applicatiorId;
            set { _applicatiorId = value; Modified = true; }
        }

        public int Position
        {
            get => _position;
            set { _position = value; Modified = true; }
        }

        public double? Contrast
        {
            get => _contrast;
            set { _contrast = value; Modified = true; }
        }

        public double? Tw
        {
            get => _tw;
            set { _tw = value; Modified = true; }
        }

        public double? Sp
        {
            get => _sp;
            set { _sp = value; Modified = true; }
        }

        public string Comments
        {
            get => _comments;
            set { _comments = value; Modified = true; }
        }

        public DateTime DateUpdated
        {
            get => _dateUpdated;
            set { _dateUpdated = value; Modified = true; }
        }

        public int Days
        {
            get => (DateTime.Now - DateCreated).Days;
        }

        public string ApplicatorName
        {
            get => Applicator.Name;
        }
    }
}
