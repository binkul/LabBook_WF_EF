using System;

namespace LabBook_WF_EF
{
    public class ExpViscosityAdo : IComparable<ExpViscosityAdo>
    {
        public bool Modified { get; set; } = false;

        private long _id;
        private long _labBookId = 1;
        public DateTime DateCreated { get; } = DateTime.Now;
        private DateTime _dateUpdate;
        public double? _pH = null;
        private string _visType;
        private double? _brook1 = null;
        private double? _brook5 = null;
        private double? _brook10 = null;
        private double? _brook20 = null;
        private double? _brook30 = null;
        private double? _brook40 = null;
        private double? _brook50 = null;
        private double? _brook60 = null;
        private double? _brook70 = null;
        private double? _brook80 = null;
        private double? _brook90 = null;
        private double? _brook100 = null;
        private string _brookComment;
        private string _brookDisc;
        private double? _brookXVis = null;
        private string _brookXRpm;
        private string _brookXDisc;
        private double? _krebs = null;
        private string _krebsComment;
        private double? _ici = null;
        private string _iciDisc;
        private string _iciComment;
        private string _temp;

        public ExpViscosityAdo() { }

        public ExpViscosityAdo(long id, long labBookId, DateTime dateCreated, DateTime dateUpdate, double? pH, string visType, 
            double? brook1, double? brook5, double? brook10, double? brook20, double? brook30, double? brook40, 
            double? brook50, double? brook60, double? brook70, double? brook80, double? brook90, double? brook100, 
            string brookComment, string brookDisc, double? brookXVis, string brookXRpm, string brookXDisc, double? krebs, 
            string krebsComment, double? ici, string iciDisc, string iciComment, string temp)
        {
            _id = id;
            _labBookId = labBookId;
            DateCreated = dateCreated;
            _dateUpdate = dateUpdate;
            _pH = pH;
            _visType = visType;
            _brook1 = brook1;
            _brook5 = brook5;
            _brook10 = brook10;
            _brook20 = brook20;
            _brook30 = brook30;
            _brook40 = brook40;
            _brook50 = brook50;
            _brook60 = brook60;
            _brook70 = brook70;
            _brook80 = brook80;
            _brook90 = brook90;
            _brook100 = brook100;
            _brookComment = brookComment;
            _brookDisc = brookDisc;
            _brookXVis = brookXVis;
            _brookXRpm = brookXRpm;
            _brookXDisc = brookXDisc;
            _krebs = krebs;
            _krebsComment = krebsComment;
            _ici = ici;
            _iciDisc = iciDisc;
            _iciComment = iciComment;
            _temp = temp;
        }

        public ExpViscosityAdo(long labBookId, DateTime dateCreated, DateTime dateUpdate, double? pH, string visType,
            double? brook1, double? brook5, double? brook10, double? brook20, double? brook30, double? brook40,
            double? brook50, double? brook60, double? brook70, double? brook80, double? brook90, double? brook100,
            string brookComment, string brookDisc, double? brookXVis, string brookXRpm, string brookXDisc, double? krebs,
            string krebsComment, double? ici, string iciDisc, string iciComment, string temp)
        {
            _labBookId = labBookId;
            DateCreated = dateCreated;
            _dateUpdate = dateUpdate;
            _pH = pH;
            _visType = visType;
            _brook1 = brook1;
            _brook5 = brook5;
            _brook10 = brook10;
            _brook20 = brook20;
            _brook30 = brook30;
            _brook40 = brook40;
            _brook50 = brook50;
            _brook60 = brook60;
            _brook70 = brook70;
            _brook80 = brook80;
            _brook90 = brook90;
            _brook100 = brook100;
            _brookComment = brookComment;
            _brookDisc = brookDisc;
            _brookXVis = brookXVis;
            _brookXRpm = brookXRpm;
            _brookXDisc = brookXDisc;
            _krebs = krebs;
            _krebsComment = krebsComment;
            _ici = ici;
            _iciDisc = iciDisc;
            _iciComment = iciComment;
            _temp = temp;
        }

        public long Id
        {
            get => _id;
            set { _id = value; Modified = true; }
        }

        public long LabBookId
        {
            get => _labBookId;
            set { _labBookId = value; Modified = true; }
        }

        public DateTime DateUpdate
        {
            get => _dateUpdate;
            set { _dateUpdate = value; Modified = true; }
        }

        public double? pH
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


        public int CompareTo(ExpViscosityAdo other)
        {
            return DateCreated.CompareTo(other.DateCreated);
        }
    }
}
