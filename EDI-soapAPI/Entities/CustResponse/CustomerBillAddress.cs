using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.CustResponse
{
    public class CustomerBillAddress
    {
        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public string companyName { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string zipCode { get; set; }
        public string countryName { get; set; }
        public object stateName { get; set; }
        public string stateCode { get; set; }
        public string city { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public long contactPhone { get; set; }
        public string contactEmail { get; set; }
        public object secondaryContactEmail { get; set; }
        public bool isIndividualEmail { get; set; }
        public string invoiceStyle { get; set; }
        public string invoiceFormat { get; set; }
        public string invoiceAfter { get; set; }
        public string invoiceCurrency { get; set; }
        public bool invoiceBatchBilling { get; set; }
        public object frequencyType { get; set; }
        public object dateOfInvoice { get; set; }
        public DeliveryMethod deliveryMethod { get; set; }
        public object dnb { get; set; }
        public object yearEstablished { get; set; }
        public int creditAmount { get; set; }
        public int availableCredit { get; set; }
        public object unbilledCredit { get; set; }
        public bool creditOverride { get; set; }
        public bool previousCreditOverride { get; set; }
        public long creditOverrideDate { get; set; }
        public bool active { get; set; }
        public PaymentTerms paymentTerms { get; set; }
        public string countryCode { get; set; }
        public object portal { get; set; }
        public int auditMarginBelowPct { get; set; }
        public int auditMarginAbovePct { get; set; }
        public int auditMarginAboveAmt { get; set; }
        public bool verifyCostBeforeInvoice { get; set; }
        public List<object> invoiceRequiredFields { get; set; }
        public List<object> invoiceVerifiedFields { get; set; }
        public List<object> invoiceDocuments { get; set; }
        public object bolSignature { get; set; }
        public object podSignature { get; set; }
        public string legacyAxAccountNumber { get; set; }
        public object axAccountNumber { get; set; }
        public object legacyBillToId { get; set; }
        public int increasedCreditAmount { get; set; }
    }
}
