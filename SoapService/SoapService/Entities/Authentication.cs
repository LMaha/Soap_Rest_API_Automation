using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace SoapService.Entities
{
	[XmlRoot(ElementName = "AUTHENTICATION", Namespace = "")]
	public class AUTHENTICATION
	{
		[XmlElement(ElementName = "USERNAME")]
		public string USERNAME { get; set; }
		[XmlElement(ElementName = "PASSWORD")]
		public string PASSWORD { get; set; }
		[XmlElement(ElementName = "ORG")]
		public string ORG { get; set; }
	}
}
