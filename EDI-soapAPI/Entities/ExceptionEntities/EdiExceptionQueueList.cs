using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
    public class EdiExceptionQueueList
    {
        public int id { get; set; }
        public EdiRejectReasonCode ediRejectReasonCode { get; set; }
        public int loadId { get; set; }
        public object ediRuleId { get; set; }
        public Customer customer { get; set; }
        public CustomerLocation customerLocation { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public object loadStopoffId { get; set; }
        public int? loadCommodityId { get; set; }
    }
}