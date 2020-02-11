using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body
	{
		[XmlElement(ElementName = "loadDTO", Namespace = "http://com.pls.load/loadService_30")]
		public LoadDTO LoadDTO { get; set; }
	}
}
