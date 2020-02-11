using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "loadStatus", Namespace = "http://com.pls.load/loadService_30")]
	public class LoadStatus
	{
		public LoadStatus()
		{
			LoadStatusId = "10";
		}
		[XmlElement(ElementName = "loadStatusId", Namespace = "http://com.pls.load/loadService_30")]
		public string LoadStatusId { get; set; }
	}

}
