using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.ResponseEntities
{
	[XmlRoot(ElementName = "CreateLoad30Response", Namespace = "http://com.pls.load/loadService_30")]
	public class CreateLoad30Response
	{
		[XmlElement(ElementName = "Response", Namespace = "http://com.pls.load/loadService_30")]
		public string Response { get; set; }
		[XmlElement(ElementName = "LoadId", Namespace = "http://com.pls.load/loadService_30")]
		public string LoadId { get; set; }
		[XmlAttribute(AttributeName = "ns2", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ns2 { get; set; }
	}
}
