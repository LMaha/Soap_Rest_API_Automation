using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoapService.Entities
{
	[XmlRoot(ElementName = "notes", Namespace = "http://com.pls.load/loadService_30")]
	public class Notes
	{
		[XmlElement(ElementName = "noteTypes", Namespace = "http://com.pls.load/loadService_30")]
		public NoteTypes NoteTypes { get; set; }
		[XmlElement(ElementName = "notesDesc", Namespace = "http://com.pls.load/loadService_30")]
		public string NotesDesc { get; set; }
	}
}
