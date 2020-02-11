using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "customerLocation", Namespace = "http://com.pls.load/loadService_30")]
	public class CustomerLocation
	{
		[XmlElement(ElementName = "customerBillAddress", Namespace = "http://com.pls.load/loadService_30")]
		public CustomerBillAddress CustomerBillAddress { get; set; }
	}

}
