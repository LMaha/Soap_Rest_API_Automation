using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SoapService
{
    //public static class Soap
    //{
       // public static string CallWebService(string url, string action, string xml, Dictionary<string, string> headers = null)
       // {
            // ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };

        //    var envelope = CreateSoapEnvelope(xml);
        //    var request = CreateWebRequest(url, action, headers);
        //    InsertSoapEnvelopeIntoWebRequest(envelope, request);

        //    var result = request.BeginGetResponse(null, null);
        //    result.AsyncWaitHandle.WaitOne();

        //    using (var response = request.EndGetResponse(result))
        //    {
        //        using (var reader = new StreamReader(response.GetResponseStream()))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        //private static XmlDocument CreateSoapEnvelope(string xml)
        //{
        //    var document = new XmlDocument();
        //    document.LoadXml(xml);
        //    return document;
        //}

        //private static HttpWebRequest CreateWebRequest(string url, string action, Dictionary<string, string> headers)
        //{
        //    var request = WebRequest.Create(url) as HttpWebRequest;
        //    request.Headers.Add("SOAPAction", action);
        //    if (headers != null)
        //    {
        //        foreach (var header in headers)
        //        {
        //            request.Headers.Add(header.Key, header.Value);
        //        }
        //    }

        //    request.ContentType = "text/xml;charset=\"utf-8\"";
        //    request.Accept = "text/xml, text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
        //    request.Method = "POST";
        //    //request.Date =;
        //    return request;
        //}

        //private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument document, HttpWebRequest request)
        //{
        //    using (var stream = request.GetRequestStream())
        //    {
        //        document.Save(stream);
        //    }
        //}

        //public static T XmlDeserialize<T>(this string toDeserialize)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //    using (StringReader textReader = new StringReader(toDeserialize))
        //    {
        //        return (T)xmlSerializer.Deserialize(textReader);
        //    }
        //}

        //public static string XmlSerialize<T>(this T toSerialize)
        //{
        //    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        //    namespaces.Add("load", "http://com.pls.load/loadService_30");
        //    namespaces.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        //    namespaces.Add("AUTHENTICATION", "ns ");
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //    using (StringWriterUtf8 textWriter = new StringWriterUtf8())
        //    {
        //        xmlSerializer.Serialize(textWriter, toSerialize, namespaces);
        //        return textWriter.ToString();
        //    }
        //}
   // }


}