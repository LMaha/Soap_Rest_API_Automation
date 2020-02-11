using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
   public class CleExpReq
    {
       
            public int loadId { get; set; }
            public List<Issue> issues { get; set; }
        
    }
}
