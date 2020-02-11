using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities
{
    public class CustomerLocation
    {
        public bool active { get; set; }
        public List<object> salesReps { get; set; }
        public bool lnErr { get; set; }
        public string locationName { get; set; }
        public PrimSalesRep primSalesRep { get; set; }
        public bool commissionable { get; set; }
        public CustomerBillAddress customerBillAddress { get; set; }
        public bool ex1Error { get; set; }
        public string primStartDate { get; set; }
        public GlCoding glCoding { get; set; }



        public int? id { get; set; }
        public int primSalesRepId { get; set; }
        // public DateTime? primStartDate { get; set; }
        public DateTime? primEndDate { get; set; }
        public int? secSalesRepId { get; set; }
        public DateTime? secStartDate { get; set; }
        public DateTime? secEndDate { get; set; }
        public int? logsCoord1Id { get; set; }
        public DateTime? logsCoord1StartDate { get; set; }
        public DateTime? logsCoord1EndDate { get; set; }
        public int? logsCoord2Id { get; set; }
        public DateTime? logsCoord2StartDate { get; set; }
        public DateTime? logsCoord2EndDate { get; set; }
        public int? logsCoord3Id { get; set; }
        public DateTime? logsCoord3StartDate { get; set; }
        public DateTime? logsCoord3EndDate { get; set; }
        public string customerBillAddressCompanyName { get; set; }
        public int plsDivisionId { get; set; }
        public int plsOfficeId { get; set; }
        public int? custSalesRepId { get; set; }
        public DateTime? custStartDate { get; set; }
        public DateTime? custEndDate { get; set; }
        public bool primary { get; set; }


   
        public string createdDate { get; set; }
     
        public string modifiedDate { get; set; }
   
    
      
    
        public string companyCode { get; set; }
        public string costCenter { get; set; }
        
    }

}
