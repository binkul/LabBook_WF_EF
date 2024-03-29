﻿using LabBook_WF_EF.Commons;
using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class CmbContrastYield
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ObservableListSource<ExpContrastClass> ExpContrastClasses { get; set; }

    }
}
