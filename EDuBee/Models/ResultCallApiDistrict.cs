using EDuBee.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Models
{
    public class ResultCallApiDistrict
    {
        public string status { get; set; }
        public List<QuanHuyen> results { get; set; }
    }
}
