using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImportDataService.Models
{
    [Table("public.temp_region")]
    public class temp_region
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int regionid { get; set; }

        [StringLength(200)]
        public string regionname { get; set; }

        public decimal? freedeliverysumm { get; set; }

        public int? priceid { get; set; }

        public decimal? deliveryprice { get; set; }

        public int? type { get; set; }

        [StringLength(25)]
        public string regionphone { get; set; }

        public decimal? discount { get; set; }
    }
}
