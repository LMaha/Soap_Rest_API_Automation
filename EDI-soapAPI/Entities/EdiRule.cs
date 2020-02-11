using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities
{
   public class EdiRule
    {
      
            public bool @override { get; set; }
            public bool enabled { get; set; }
            public bool active { get; set; }
            public List<EdiRuleCommitType> ediRuleCommitTypes { get; set; }
            public Location location { get; set; }
            public Equipment equipment { get; set; }
            public string originCityStateZip { get; set; }
            public string originCity { get; set; }
            public string originState { get; set; }
            public string originZipCode { get; set; }
            public string destCityStateZip { get; set; }
            public string destinationCity { get; set; }
            public string destinationState { get; set; }
            public string destinationZipCode { get; set; }
            public string destinationCityStateZip { get; set; }
            public string maxPerDay { get; set; }
            public string commit { get; set; }
            public string surge { get; set; }
            public string destinationCountry { get; set; }
            public string originCountry { get; set; }


      

     
    
  
       
    }
}
