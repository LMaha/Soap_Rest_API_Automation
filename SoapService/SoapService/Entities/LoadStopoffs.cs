using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "loadStopoffs", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadStopoffs
	{
		[XmlElement(ElementName = "nodeCode", Namespace = "http://com.pls.load/loadService_30")]
		public string NodeCode { get; set; }
		[XmlElement(ElementName = "packageType", Namespace = "http://com.pls.load/loadService_30")]
		public string PackageType { get; set; }
		[XmlElement(ElementName = "pnetDate", Namespace = "http://com.pls.load/loadService_30")]
		public string PnetDate { get; set; }
		[XmlElement(ElementName = "pnetTime", Namespace = "http://com.pls.load/loadService_30")]
		public string PnetTime { get; set; }
		[XmlElement(ElementName = "pnltDate", Namespace = "http://com.pls.load/loadService_30")]
		public string PnltDate { get; set; }
		[XmlElement(ElementName = "pnltTime", Namespace = "http://com.pls.load/loadService_30")]
		public string PnltTime { get; set; }
		[XmlElement(ElementName = "seqInRoute", Namespace = "http://com.pls.load/loadService_30")]
		public string SeqInRoute { get; set; }
		[XmlElement(ElementName = "stopoffCity", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffCity { get; set; }
		[XmlElement(ElementName = "stopoffCompanyName", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffCompanyName { get; set; }
		[XmlElement(ElementName = "stopoffCountry", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffCountry { get; set; }
		[XmlElement(ElementName = "stopoffLoadAction", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffLoadAction { get; set; }
		[XmlElement(ElementName = "stopoffSelectionType", Namespace = "http://com.pls.load/loadService_30")]
		public StopoffSelectionType StopoffSelectionType { get; set; }
		[XmlElement(ElementName = "stopoffState", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffState { get; set; }
		[XmlElement(ElementName = "stopoffStateCode", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffStateCode { get; set; }
		[XmlElement(ElementName = "stopoffStreetAddress1", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffStreetAddress1 { get; set; }
		[XmlElement(ElementName = "stopoffZipcode", Namespace = "http://com.pls.load/loadService_30")]
		public string StopoffZipcode { get; set; }
		[XmlElement(ElementName = "weight", Namespace = "http://com.pls.load/loadService_30")]
		public string Weight { get; set; }
	}
}
