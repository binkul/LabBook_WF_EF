using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpGloss
    {
        private long _id;
        private long _labbookId;
        private long _applicatiorId;
        private int _position;
        private string _substrate;
        public double? _gloss20;
        public double? _gloss60;
        public double? _gloss85;
        public string _comment;
        public DateTime DateCreated { get; set; } = DateTime.Today;
        public DateTime _dateUpdated = DateTime.Today;

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

        public string Substrate
        {
            get => _substrate;
            set { _substrate = value; Modified = true; }
        }

        public double? Gloss20
        {
            get => _gloss20;
            set { _gloss20 = value; Modified = true; }
        }

        public double? Gloss60
        {
            get => _gloss60;
            set { _gloss60 = value; Modified = true; }
        }

        public double? Gloss85
        {
            get => _gloss85;
            set { _gloss85 = value; Modified = true; }
        }

        public string Comments
        {
            get => _comment;
            set { _comment = value; Modified = true; }
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
