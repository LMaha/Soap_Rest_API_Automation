using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "noteTypes", Namespace = "http://com.pls.load/loadService_30")]
	public class NoteTypes
	{
		public NoteTypes()
		{
			Id = "1";
		}
		[XmlElement(ElementName = "id", Namespace = "http://com.pls.load/loadService_30")]
		public string Id { get; set; }
	}
}
