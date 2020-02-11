using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.CustResponse
{
    public class CustomerLocation
    {
        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public string locationName { get; set; }
        public PrimSalesRep primSalesRep { get; set; }
        public string primStartDate { get; set; }
        public object primEndDate { get; set; }
        public bool active { get; set; }
        public CustomerBillAddress customerBillAddress { get; set; }
        public GlCoding glCoding { get; set; }
        public List<object> salesReps { get; set; }
        public string companyCode { get; set; }
        public string costCenter { get; set; }
        public bool primary { get; set; }
        public bool commissionable { get; set; }
    }
}
