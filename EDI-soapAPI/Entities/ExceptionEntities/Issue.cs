using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.ExceptionEntities
{
   public class Issue
    {
     
            public int ediExceptionId { get; set; }
            public int issueType { get; set; }
            public string description { get; set; }
            public string updatedValue { get; set; }
            public Country country { get; set; }
        
    }
}
