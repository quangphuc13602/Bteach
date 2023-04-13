using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Classes
{
    public class EditDoc
    {
        public int? Idcategory { get; set; }
        public string Name { get; set; }
        public IFormFile FileImage { get; set; }
        public decimal? Price { get; set; }
        public IFormFile DocFile { get; set; }
        public string Idattribute { get; set; }
        public string Summary { get; set; }
        public string Contents { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
