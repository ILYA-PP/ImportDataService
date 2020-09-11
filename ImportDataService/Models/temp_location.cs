using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportDataService.Models
{
    [Table("public.temp_location")]
    [Serializable]
    public partial class temp_location
    {
        [Key]
        public int location_id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [XmlElement("gescodelocation")]
        public int gescodelocation { get; set; }

        [XmlElement("organization")]
        [StringLength(8000)]
        public string organization { get; set; }
        [XmlElement("cityid")]
        public int cityid { get; set; }
        [XmlElement("streetandbuilding")]
        [StringLength(8000)]
        public string streetandbuilding { get; set; }
        [XmlElement("deliverydate")]
        [Column(TypeName = "date")]
        public DateTime deliverydate { get; set; }
        [XmlElement("phone")]
        [StringLength(8000)]
        public string phone { get; set; }
        [XmlElement("x")]
        public decimal x { get; set; }
        [XmlElement("y")]
        public decimal y { get; set; }
        [XmlElement("type")]
        public int type { get; set; }
        [XmlElement("timetablerow")]
        [StringLength(8000)]
        public string timetablerow { get; set; }
        [XmlElement("timetablefordelive")]
        [StringLength(8000)]
        public string timetablefordelive { get; set; }
        [XmlElement("daysaway")]
        public int daysaway { get; set; }
        [XmlElement("timetonextdaydelivery")]
        public string timetonextdaydelivery { get; set; }
        [XmlElement("dateupd")]
        public DateTime dateupd { get; set; }
    }
}
