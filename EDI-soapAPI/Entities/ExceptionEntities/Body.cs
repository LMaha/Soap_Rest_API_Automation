using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
    public class Body
    {
        public int resultSize { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public List<EdiIssuesDTO> ediIssuesDTO { get; set; }
    }

}
