using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SoapService.Entities
{
	[XmlRoot(ElementName = "loadDTO", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadDTO
	{
		public LoadDTO()
		{
			IsOutbound = "true";
		}
		[XmlElement(ElementName = "customer", Namespace = "http://com.pls.load/loadService_30")]
		public Customer Customer { get; set; }
		[XmlElement(ElementName = "customerLocation", Namespace = "http://com.pls.load/loadService_30")]
		public CustomerLocation CustomerLocation { get; set; }
		[XmlElement(ElementName = "isOutbound", Namespace = "http://com.pls.load/loadService_30")]

		public string IsOutbound { get; set; }

		[XmlElement(ElementName = "loadCommodities", Namespace = "http://com.pls.load/loadService_30")]
		public LoadCommodities LoadCommodities { get; set; }
		[XmlElement(ElementName = "loadOriginDestination", Namespace = "http://com.pls.load/loadService_30")]
		public LoadOriginDestination LoadOriginDestination { get; set; }
		[XmlElement(ElementName = "loadReferenceFields", Namespace = "http://com.pls.load/loadService_30")]
		public List<LoadReferenceFields> LoadReferenceFields { get; set; }
		[XmlElement(ElementName = "loadStatus", Namespace = "http://com.pls.load/loadService_30")]
		public LoadStatus LoadStatus { get; set; }
		[XmlElement(ElementName = "notes", Namespace = "http://com.pls.load/loadService_30")]
		public List<Notes> Notes { get; set; }
		[XmlElement(ElementName = "ppdCol", Namespace = "http://com.pls.load/loadService_30")]
		[System.ComponentModel.DefaultValue("PPD")]
		public string PpdCol { get; set; }

		[XmlElement(ElementName = "shipmentNumber", Namespace = "http://com.pls.load/loadService_30")]
		public string ShipmentNumber { get; set; }
	}

}
