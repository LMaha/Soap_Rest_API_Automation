using SoapService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace SoapService
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        //public Envelope SoapEnvelop  { get; set; }

        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "load", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Load { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }





    }
}
