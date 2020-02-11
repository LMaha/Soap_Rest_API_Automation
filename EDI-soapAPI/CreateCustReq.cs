using EDI_soapAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI
{
   public class CreateCustReq
    {
        public List<Contact> contacts { get; set; }
        public List<CustomerNote> customerNotes { get; set; }
        public List<object> customerTags { get; set; }
        public List<BillToAddress> billToAddresses { get; set; }
        public AccountManager accountManager { get; set; }
        public List<CustomerLocation> customerLocations { get; set; }
        public List<EdiRule> ediRules { get; set; }
        public string companyName { get; set; }

        public int id { get; set; }
    }
}
