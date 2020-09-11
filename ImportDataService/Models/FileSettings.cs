using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportDataService.Models
{
    public class FileSettings
    {
        public string FirstFolder{ get; set; }
        public string SecondFolder{ get; set; }
        public string RegionFile{ get; set; }
        public string CityFile{ get; set; }
        public string StockFile{get; set; }
        public string PriceFile{get; set; }
        public string GoodsFile{get; set; }
        public string PharmacyFile{ get; set; } 
    }
}
