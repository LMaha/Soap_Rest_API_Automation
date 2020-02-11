using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "loadCommodities", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadCommodities
	{
		public LoadCommodities()
		{
			Pallets = "19";
			PiecesValue = "19";
			TotalPieces = "19";
			WeightIbs = "43890";
		}
		[XmlElement(ElementName = "height", Namespace = "http://com.pls.load/loadService_30")]
		public string Height { get; set; }
		[XmlElement(ElementName = "length", Namespace = "http://com.pls.load/loadService_30")]
		public string Length { get; set; }
		[XmlElement(ElementName = "pallets", Namespace = "http://com.pls.load/loadService_30")]

		public string Pallets { get; set; }
		[XmlElement(ElementName = "piecesValue", Namespace = "http://com.pls.load/loadService_30")]

		public string PiecesValue { get; set; }
		[XmlElement(ElementName = "totalPieces", Namespace = "http://com.pls.load/loadService_30")]

		public string TotalPieces { get; set; }
		[XmlElement(ElementName = "weightIbs", Namespace = "http://com.pls.load/loadService_30")]

		public string WeightIbs { get; set; }
		[XmlElement(ElementName = "width", Namespace = "http://com.pls.load/loadService_30")]
		public string Width { get; set; }
	}
}
