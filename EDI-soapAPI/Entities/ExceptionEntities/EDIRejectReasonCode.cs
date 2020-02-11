using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
    public class EdiRejectReasonCode
    {
        public int id { get; set; }
        public bool active { get; set; }
        public string description { get; set; }
        public string name { get; set; }
    }
}
