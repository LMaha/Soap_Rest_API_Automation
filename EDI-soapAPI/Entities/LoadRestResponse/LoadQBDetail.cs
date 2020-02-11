using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.LoadRestResponse
{
    public class LoadQBDetail
    {
        public int accountOwnerId { get; set; }
        public string accountOwner { get; set; }
        public string customerName { get; set; }
        public int loadId { get; set; }
        public string loadStatus { get; set; }
        public string originCSZ { get; set; }
        public int stops { get; set; }
        public string destinationCSZ { get; set; }
        public string pickupNumber { get; set; }
        public object equipmentName { get; set; }
        public object scac { get; set; }
        public long originPnetDate { get; set; }
        public object originTimezone { get; set; }
        public string originPnetTime { get; set; }
        public long originPnltDate { get; set; }
        public string originPnltTime { get; set; }
        public long destinationDnetDate { get; set; }
        public object destTimezone { get; set; }
        public string destinationDnetTime { get; set; }
        public long destinationDnltDate { get; set; }
        public string destinationDnltTime { get; set; }
        public object actualPickDate { get; set; }
        public object actualPickTime { get; set; }
        public object actualDeliveredDate { get; set; }
        public object actualDeliveredTime { get; set; }
        public bool isConfirmPickupEnabled { get; set; }
        public bool isConfirmDeliveryEnabled { get; set; }
        public object stopOffMaxDateTime { get; set; }
        public int loadStatusId { get; set; }
        public bool isInvoiceAdjustmentRequested { get; set; }
        public bool isInvoiceProcessed { get; set; }
        public int totalRecords { get; set; }
        public int loadPriority { get; set; }
        public bool isLoadBooked { get; set; }
        public bool ediOutBoundMessages { get; set; }
        public bool isEdi { get; set; }
        public string originPnetDateTimeZone { get; set; }
        public string originPnltDateTimeZone { get; set; }
        public string destDnetDateTimeZone { get; set; }
        public string destDnltDateTimeZone { get; set; }
        public string actualPickDateTimeZone { get; set; }
        public string actualDeliveredTimeZone { get; set; }
        public object pickupTimeZoneString { get; set; }
        public object deliveryTimeZoneString { get; set; }
        public string pickupTimeZone { get; set; }
        public string deliveryTimeZone { get; set; }
    }
}
