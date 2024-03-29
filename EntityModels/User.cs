﻿using LabBook_WF_EF.Commons;
using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Permission { get; set; }
        public string Identifier { get; set; }
        public bool? Active { get; set; }

        public virtual ObservableListSource<ExpLabBook> ExpLabBook { get; set; }
    }
}
