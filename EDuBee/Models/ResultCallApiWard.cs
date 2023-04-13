using EDuBee.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDuBee.Models
{
    public class ResultCallApiWard
    {
        public string status { get; set; }
        public List<PhuongXa> results { get; set; }
    }
}
