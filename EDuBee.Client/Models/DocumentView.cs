using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Client.Models
{
    public class DocumentView
    {
        public int iddocument { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string summary { get; set; }
        public string contents { get; set; }
        public decimal? price { get; set; }
        public DateTime? createDate { get; set; }
        public int? idcategory { get; set; }
        public string idattribute { get; set; }
        public string file { get; set; }
        public bool? status { get; set; }
    }
}
