using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{

	[XmlRoot(ElementName = "loadOriginDestination", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadOriginDestination
	{
		public LoadOriginDestination()
		{
			DestinationCity = "Stkton";
			DestinationCompanyName = "Blue Line - Stockton";
			DestinationCountry = "United States of America";
			DestinationState = "California";
			DestinationStateCode = "CA";
			DestinationStreetAddress1 = "2332 Station Drive Suite B";
			DestinationZipcode = "95215";
			DestinationSeqInRoute = "2";
			DestinationNodeCode = "TB-25-415";
			Mileage = "9";
			DestinationWeight = "43890";
			DestinationQuantity = "798";
			OriginCity = "Stkton";
			OriginCompanyName = "Ardent Mills";
			OriginCountry = "United States of America";
			OriginPickupNumber = "5593529BD";
			OriginState = "California";
			OriginStateCode = "CA";
			OriginStreetAddress1 = "3939 Producers Drive";
			OriginZipcode = "95206";
			OriginNodeCode = "TB-25-509134";
			OriginQuantity = "798";
			OriginWeight = "43890";
			PickupBol = "526185BD";


		}
		[XmlElement(ElementName = "destinationCity", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationCity { get; set; }

		[XmlElement(ElementName = "destinationCompanyName", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationCompanyName { get; set; }

		[XmlElement(ElementName = "destinationCountry", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationCountry { get; set; }
		[XmlElement(ElementName = "destinationPnetDate", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationPnetDate { get; set; }
		[XmlElement(ElementName = "destinationPnetTime", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationPnetTime { get; set; }
		[XmlElement(ElementName = "destinationPnltDate", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationPnltDate { get; set; }
		[XmlElement(ElementName = "destinationPnltTime", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationPnltTime { get; set; }
		[XmlElement(ElementName = "destinationState", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationState { get; set; }
		[XmlElement(ElementName = "destinationStateCode", Namespace = "http://com.pls.load/loadService_30")]

		public string DestinationStateCode { get; set; }
		[XmlElement(ElementName = "destinationStreetAddress1", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationStreetAddress1 { get; set; }

		[XmlElement(ElementName = "destinationZipcode", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationZipcode { get; set; }
		[XmlElement(ElementName = "destinationSeqInRoute", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationSeqInRoute { get; set; }
		[XmlElement(ElementName = "destinationNodeCode", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationNodeCode { get; set; }

		[XmlElement(ElementName = "destinationQuantity", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationQuantity { get; set; }
		[XmlElement(ElementName = "destinationWeight", Namespace = "http://com.pls.load/loadService_30")]
		public string DestinationWeight { get; set; }

		[XmlElement(ElementName = "mileage", Namespace = "http://com.pls.load/loadService_30")]
		public string Mileage { get; set; }
		[XmlElement(ElementName = "originCity", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginCity { get; set; }
		[XmlElement(ElementName = "originCompanyName", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginCompanyName { get; set; }
		[XmlElement(ElementName = "originCountry", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginCountry { get; set; }
		[XmlElement(ElementName = "originPickupNumber", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginPickupNumber { get; set; }
		[XmlElement(ElementName = "originPnetDate", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginPnetDate { get; set; }
		[XmlElement(ElementName = "originPnetTime", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginPnetTime { get; set; }
		[XmlElement(ElementName = "originPnltDate", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginPnltDate { get; set; }
		[XmlElement(ElementName = "originPnltTime", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginPnltTime { get; set; }
		[XmlElement(ElementName = "originState", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginState { get; set; }
		[XmlElement(ElementName = "originStateCode", Namespace = "http://com.pls.load/loadService_30")]

		public string OriginStateCode { get; set; }
		[XmlElement(ElementName = "originStreetAddress1", Namespace = "http://com.pls.load/loadService_30")]

		public string OriginStreetAddress1 { get; set; }

		[XmlElement(ElementName = "originZipcode", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginZipcode { get; set; }
		[XmlElement(ElementName = "originNodeCode", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginNodeCode { get; set; }
		[XmlElement(ElementName = "originQuantity", Namespace = "http://com.pls.load/loadService_30")]
		public string OriginQuantity { get; set; }
		[XmlElement(ElementName = "originWeight", Namespace = "http://com.pls.load/loadService_30")]

		public string OriginWeight { get; set; }
		[XmlElement(ElementName = "pickupBol", Namespace = "http://com.pls.load/loadService_30")]
		public string PickupBol { get; set; }
	}
}
