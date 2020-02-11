using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	
	
	public class Header
	{
		[XmlElement(ElementName = "AUTHENTICATION", Namespace = "")]
		public AUTHENTICATION AUTHENTICATION { get; set; }
	}
}
