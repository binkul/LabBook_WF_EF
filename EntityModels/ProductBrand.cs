using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace LabBook_WF_EF.EntityModels
{
    public partial class ProductBrand
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public bool? IsActive { get; set; }
        public string Name { get; set; }
        public long BuyerId { get; set; }
        public string Varanty { get; set; }
        public long MsdsId { get; set; }
        public DateTime Created { get; set; }
        public long LoginId { get; set; }
    }
}
