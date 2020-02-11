using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
    public class EdiIssuesDTO
    {
        public int loadId { get; set; }
        public string customerName { get; set; }
        public string customerLocationName { get; set; }
        public List<EdiExceptionQueueList> ediExceptionQueueList { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
    }
}
