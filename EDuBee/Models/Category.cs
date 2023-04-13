using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EDuBee.Models
{
    public partial class Category
    {
        public Category()
        {
            Document = new HashSet<Document>();
        }

        public int Idcategory { get; set; }
        public string Name { get; set; }
        public int? Cate { get; set; }

        public virtual ICollection<Document> Document { get; set; }
    }
}
