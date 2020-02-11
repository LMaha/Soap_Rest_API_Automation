using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "loadReferenceFields", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadReferenceFields
	{
		public LoadReferenceFields()
		{
			Value = "5593529BD";
		}
		
		[XmlElement(ElementName = "invoiceRequiredField", Namespace = "http://com.pls.load/loadService_30")]
		public InvoiceRequiredField InvoiceRequiredField { get; set; }
		[XmlElement(ElementName = "value", Namespace = "http://com.pls.load/loadService_30")]
		public string Value { get; set; }
	}
}
