using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportDataService.Models
{
    public class stock
    {
        public int id { get; set; }
        public int pharmacy_id { get; set; }
        public int goods_id { get; set; }
        public int state_id { get; set; }
        public int count { get; set; }
        public double price { get; set; }
    }
}
