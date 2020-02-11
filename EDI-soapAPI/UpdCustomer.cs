using EDI_soapAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI
{
   public class UpdCustomer
    {
        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public string companyName { get; set; }
        public object dba { get; set; }
        public object ein { get; set; }
        public object companySite { get; set; }
        public Industry industry { get; set; }
        public object sic { get; set; }
        public object bolSignature { get; set; }
        public object podSignature { get; set; }
        public object legacyId { get; set; }
        public List<Contact> contacts { get; set; }
        public List<object> customerTags { get; set; }
        public List<BillToAddress> billToAddresses { get; set; }
        public List<CustomerLocation> customerLocations { get; set; }
        public List<CustomerNote> customerNotes { get; set; }
        public List<EdiRule> ediRules { get; set; }
        public bool outboundMessages { get; set; }
        public string currentDate { get; set; }
        public bool shipsFrequently { get; set; }
        public bool ediCustomer { get; set; }
        public FirstAddress firstAddress { get; set; }
        public List<object> customerTagsData { get; set; }
    }
}
