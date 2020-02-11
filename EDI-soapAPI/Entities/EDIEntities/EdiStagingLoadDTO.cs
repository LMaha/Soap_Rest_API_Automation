using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.EDIEntities
{
    public class EdiStagingLoadsDTO
    {
        public int loadId { get; set; }
        public string originStateCityZip { get; set; }
        public string destStateCityZip { get; set; }
        public string originPnetDateTimeZone { get; set; }
        public string originPnltDateTimeZone { get; set; }
        public string destDnetDateTimeZone { get; set; }
        public string destDnltDateTimeZone { get; set; }
        public object shippmentNumber { get; set; }
        public string equipmentName { get; set; }
        public object commit { get; set; }
        public object accept { get; set; }
        public int plsRate { get; set; }
        public int marketRate { get; set; }
    }
}
