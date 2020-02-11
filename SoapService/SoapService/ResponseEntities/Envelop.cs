using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.ResponseEntities
{
	[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public class Envelope
	{
		[XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
		public string Header { get; set; }
		[XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName = "SOAP-ENV", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string SOAPENV { get; set; }
	}

}
