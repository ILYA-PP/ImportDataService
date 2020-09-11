using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImportDataService.Models
{
    [Table("temp_city")]
    public class temp_city
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cityid { get; set; }

        [StringLength(100)]
        public string cityname { get; set; }

        public int? regionid { get; set; }

        public int? ismaincity { get; set; }

        public int? ismappedcity { get; set; }

        public int? type { get; set; }

        public int? rangid { get; set; }

        public int? flagdelivery { get; set; }

        public int? priceid { get; set; }

        [StringLength(100)]
        public string citynameprepos { get; set; }

        public int? priceid_mapp { get; set; }
    }
}
