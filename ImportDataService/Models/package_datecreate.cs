using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportDataService.Models
{
    [XmlType("package", Namespace = "")]
    public class package_datecreate
    {
        [XmlElement("apteka")]
        public temp_location[] locations { get; set; }
    }
}
