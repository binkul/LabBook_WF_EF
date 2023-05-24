using LabBook_WF_EF.Commons;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpViscosity
    {
        private long _id;
        private long _labbookId;
        public DateTime DateCreated { get; set; }
        private DateTime _dateUpdate;
        private double? _pH;
        private string _visType = "brookfield";
        private double? _brook1;
        private double? _brook5;
        private double? _brook10;
        private double? _brook20;
        private double? _brook30;
        private double? _brook40;
        private double? _brook50;
        private double? _brook60;
        private double? _brook70;
        private double? _brook80;
        private double? _brook90;
        private double? _brook100;
        private string _brookComment;
        private string _brookDisc;
        private double? _brookXVis;
        private string _brookXRpm;
        private string _brookXDisc;
        private double? _krebs;
        private string _krebsComment;
        private double? _ici;
        private string _iciDisc;
        private string _iciComment;
        private string _temp;

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

        public DateTime DateUpdate
        {
            get => _dateUpdate;
            set { _dateUpdate = value; Modified = true; }
        }

        public int Days
        {
            get => (DateTime.Now - DateCreated).Days;
        }

        public double? PH
        {
            get => _pH;
            set { _pH = value; Modified = true; }
        }

        public string VisType
        {
            get => _visType;
            set { _visType = value; Modified = true; }
        }

        public double? Brook1
        {
            get => _brook1;
            set { _brook1 = value; Modified = true; }
        }

        public double? Brook5
        {
            get => _brook5;
            set { _brook5 = value; Modified = true; }
        }

        public double? Brook10
        {
            get => _brook10;
            set { _brook10 = value; Modified = true; }
        }

        public double? Brook20
        {
            get => _brook20;
            set { _brook20 = value; Modified = true; }
        }

        public double? Brook30
        {
            get => _brook30;
            set { _brook30 = value; Modified = true; }
        }

        public double? Brook40
        {
            get => _brook40;
            set { _brook40 = value; Modified = true; }
        }

        public double? Brook50
        {
            get => _brook50;
            set { _brook50 = value; Modified = true; }
        }

        public double? Brook60
        {
            get => _brook60;
            set { _brook60 = value; Modified = true; }
        }

        public double? Brook70
        {
            get => _brook70;
            set { _brook70 = value; Modified = true; }
        }

        public double? Brook80
        {
            get => _brook80;
            set { _brook80 = value; Modified = true; }
        }

        public double? Brook90
        {
            get => _brook90;
            set { _brook90 = value; Modified = true; }
        }

        public double? Brook100
        {
            get => _brook100;
            set { _brook100 = value; Modified = true; }
        }

        public string BrookComment
        {
            get => _brookComment;
            set { _brookComment = value; Modified = true; }
        }

        public string BrookDisc
        {
            get => _brookDisc;
            set { _brookDisc = value; Modified = true; }
        }

        public double? BrookXVis
        {
            get => _brookXVis;
            set { _brookXVis = value; Modified = true; }
        }

        public string BrookXRpm
        {
            get => _brookXRpm;
            set { _brookXRpm = value; Modified = true; }
        }

        public string BrookXDisc
        {
            get => _brookXDisc;
            set { _brookXDisc = value; Modified = true; }
        }

        public double? Krebs
        {
            get => _krebs;
            set { _krebs = value; Modified = true; }
        }

        public string KrebsComment
        {
            get => _krebsComment;
            set { _krebsComment = value; Modified = true; }
        }

        public double? Ici
        {
            get => _ici;
            set { _ici = value; Modified = true; }
        }

        public string IciDisc
        {
            get => _iciDisc;
            set { _iciDisc = value; Modified = true; }
        }

        public string IciComment
        {
            get => _iciComment;
            set { _iciComment = value; Modified = true; }
        }

        public string Temp
        {
            get => _temp;
            set { _temp = value; Modified = true; }
        }
    }
}
