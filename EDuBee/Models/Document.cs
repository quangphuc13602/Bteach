using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EDuBee.Models
{
    public partial class Document
    {
        public int Iddocument { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public string Contents { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Idcategory { get; set; }
        public string Idattribute { get; set; }
        public string File { get; set; }
        public bool? Status { get; set; }

        public virtual Category IdcategoryNavigation { get; set; }
    }
}
