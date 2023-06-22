﻿using System;

namespace LabBook_WF_EF.EntityModels
{
    public partial class ExpNormResult
    {
        private long _id;
        private long _labbookId;
        private int _position;
        private int _pageNumber;
        private string _description;
        private string _norm;
        private string _requirement;
        private string _resultByString;
        private double? _resultByValue;
        private string _substrate;
        private string _unit;
        private string _comment;

        public DateTime DateCreated { get; set; } = DateTime.Today;
        private DateTime _dateUpdated = DateTime.Today;

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

        public DateTime DateUpdated
        {
            get => _dateUpdated;
            set { _dateUpdated = value; Modified = true; }
        }

        public int Position
        {
            get => _position;
            set { _position = value; Modified = true; }
        }

        public int PageNumber
        {
            get => _pageNumber;
            set { _pageNumber = value; Modified = true; }
        }

        public string Description
        {
            get => _description;
            set { _description = value; Modified = true; }
        }

        public string Norm
        {
            get => _norm;
            set { _norm = value; Modified = true; }
        }

        public string Requirement
        {
            get => _requirement;
            set { _requirement = value; Modified = true; }
        }

        public string ResultByString
        {
            get => _resultByString;
            set { _resultByString = value; Modified = true; }
        }

        public double? ResultByValue
        {
            get => _resultByValue;
            set { _resultByValue = value; Modified = true; }
        }

        public string Substrate
        {
            get => _substrate;
            set { _substrate = value; Modified = true; }
        }

        public string Unit
        {
            get => _unit;
            set { _unit = value; Modified = true; }
        }

        public string Comment
        {
            get => _comment;
            set { _comment = value; Modified = true; }
        }


        public int Days
        {
            get => (DateTime.Now - DateCreated).Days;
        }
    }
}
