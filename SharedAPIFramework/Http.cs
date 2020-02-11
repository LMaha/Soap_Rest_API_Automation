using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using SharedAPIFramework;
using System.Net;
using System.Xml.Serialization;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace SharedAPIFramework
{
    public class Http : IDisposable
    {
        private HttpClient _client;
        private Writer _writer;
        private RandomHelper _random;
        public Http(string baseAddress, IDictionary<string, string> headers, IEnumerable<string> cookies, Writer writer, RandomHelper random, ExtentTestManager etm=null)
        {
           

            _writer = writer;
            _random = random;
            
             
            if (cookies != null)
            {
                var cookieContainer = new CookieContainer();
                foreach (var cookie in cookies)
                {
                    var tokCookie = cookie.Split(';');

                    var dictionary = new List<KeyValuePair<string, string>>();
                    foreach (var token in tokCookie)
                    {
                        var tokToken = token.Split('=');
                        if (tokToken.Count() == 2)
                        {
                            dictionary.Add(new KeyValuePair<string, string>(tokToken[0], tokToken[1]));
                        }
                    }

                    var keyValue = dictionary.First(d => d.Key.ToLower().Trim() != "path" && d.Key.ToLower().Trim() != "domain");
                    //cookieContainer.Add(new Cookie(keyValue.Key, keyValue.Value, dictionary.First(d => d.Key.ToLower().Trim() == "path").Value, dictionary.First(d => d.Key.ToLower().Trim() == "domain").Value));
                    cookieContainer.Add(new Uri(baseAddress), new Cookie(keyValue.Key, keyValue.Value));
                    //{ Domain = "DomainName" }
                    //headers.Add(keyValue.Key, keyValue.Value);
                    //cookieContainer.Add(new Cookie(keyValue.Key.ToString(), keyValue.Value.ToString()));
                }

                var handler = new HttpClientHandler()
                {
                    CookieContainer = cookieContainer
                };
                _client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(baseAddress)
                };

            }
            else
            {
                _client = new HttpClient()
                {
                    BaseAddress = new Uri(baseAddress)
                };
               
            }

                SetHeaders(headers);

        }

        public Http(Writer writer,RandomHelper random)
        {
            _random = random;
            _writer = writer;


        }

        public void SetHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
        public T Get<T>(string url)
        {
          //  _writer.WriteLine("Sending GET request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending GET request to " + _client.BaseAddress + url);           
            var message = _client.GetAsync(url).Result;
            return (T)DeserializeObject<T>(message);
        }

        public object Get(string url)
        {
          //  _writer.WriteLine("Sending GET request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending GET request to " + _client.BaseAddress + url);
            var message = _client.GetAsync(url).Result;
            return message;
        }

        public string GetFile(string url)
        {
           // _writer.WriteLine("Sending GET request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending GET request to " + _client.BaseAddress + url);
            var message = _client.GetAsync(url).Result;
            var stream = message.Content.ReadAsStreamAsync().Result;
            var path = Path.GetTempFileName();
            using (var file = File.Create(path))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(file);
                return path;
            }
        }

        public string GetFileAndConvert(string url)
        {
           // _writer.WriteLine("Sending GET request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending GET request to " + _client.BaseAddress + url);
            var message = _client.GetAsync(url).Result;
            var fileText = message.Content.ReadAsStringAsync().Result;
            fileText = JsonConvert.DeserializeObject<string>(fileText);
            byte[] stream = System.Convert.FromBase64String(fileText);
            var path = Path.GetTempFileName();

            File.WriteAllBytes(path, stream);
            return path;
        }

        public T Post<T>(string url, object payload, bool logRequest = false)
        {
           // _writer.WriteLine("Sending POST request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            string content = PayloadToString(payload);

            if (logRequest)
            {
                WriteToFile(content, "Request");
            }

            try
            {
                var message = _client.PostAsync(url, StringToContent(content)).Result;
                return (T)DeserializeObject<T>(message);
            }
            catch (Exception e)
            {
                //_writer.WriteLine("Request failed: " + e.InnerException.Message);
                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, "Request failed: " + e.Message);
                throw e;
            }
        }

        public object Post<T>(string url, object payload, bool isNegTestCase, bool logRequest = false)
        {
            // _writer.WriteLine("Sending POST request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            string content = PayloadToString(payload);

            if (logRequest)
            {
                WriteToFile(content, "Request");
            }

            try
            {
                var message = _client.PostAsync(url, StringToContent(content)).Result;
                return (object)DeserializeObject<T>(message, isNegTestCase);
            }
            catch (Exception e)
            {
                //_writer.WriteLine("Request failed: " + e.InnerException.Message);
                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, "Request failed: " + e.Message);
                throw e;




            }
        }
        public string PostXMLData(string url, string requestXml, bool logRequest = false)
        {
           // _writer.WriteLine("Sending POST request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            string content = requestXml;

            if (logRequest)
            {
                WriteToFile(content, "Request");
            }

            try
            {
                var message = _client.PostAsync(url, StringToContentXML(content)).Result;
            }
            catch (Exception e)
            {
                _writer.WriteLine("Request failed: " + e.InnerException.Message);
                throw e;
            }

            return null;
        }

        public T PostFile<T>(string url, string path)
        {
           // _writer.WriteLine("Sending POST request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            var stream = new StreamContent(File.Open(path, FileMode.Open));
            var content = new MultipartFormDataContent();
            content.Add(stream, "file", Path.GetFileName(path));

            var message = _client.PostAsync(url, content).Result;
            return (T)DeserializeObject<T>(message);
        }

        public async Task<object> SendFileAsRequestAsync(string url, string filename)
        {
           // _writer.WriteLine("Sending POST request to " + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + url);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", filename);
            var content = System.IO.File.ReadAllText(path);
            WriteToFile(content, "Request");

            var message = _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            message.EnsureSuccessStatusCode();
            var Response = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            WriteToFile(Response, "Response");

            return Response;
        }

        public async Task<TResponse> PostAsync<TResponse>(string url, string filename)
        {
           // _writer.WriteLine("Sending POST request to " + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " +  url);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", filename);
            var content = System.IO.File.ReadAllText(path);
            WriteToFile(content, "Request");
            var message = _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            message.EnsureSuccessStatusCode();
            var Response = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            WriteToFile(Response, "Response");
            return JsonConvert.DeserializeObject<TResponse>(Response);
        }

        public async Task<TResponse> PostAsync<TResponse, TRequest>(string url, string filename)
        {
            //_writer.WriteLine("Sending POST request to " + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", filename);
            var content = System.IO.File.ReadAllText(path);
            WriteToFile(content, "Request");
            var message = _client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            message.EnsureSuccessStatusCode();
            var Response = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            WriteToFile(Response, "Response");
            return JsonConvert.DeserializeObject<TResponse>(Response);
        }

        public async Task<object> SendObjectAsPayload(string url, object payload)
        {
           // _writer.WriteLine("Sending POST request to " + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            var message = _client.PostAsync(url, new StringContent(payload.ToString(), Encoding.UTF8, "application/json")).Result;
            message.EnsureSuccessStatusCode();
            var Response = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            WriteToFile(Response, "Response");

            return Response;
        }

        public T Put<T>(string url, object payload)
        {
           // _writer.WriteLine("Sending PUT request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request to " + _client.BaseAddress + url);
            string content = PayloadToString(payload);
            var message = _client.PutAsync(url, PayloadToContent(payload)).Result;
            return (T)DeserializeObject<T>(message);
        }

        

        public T Delete<T>(string url)
        {
            //_writer.WriteLine("Sending DELETE request to " + _client.BaseAddress + url);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending DELETE request to " + _client.BaseAddress + url);
            var message = _client.DeleteAsync(url).Result;
            return (T)DeserializeObject<T>(message);
        }


        private object DeserializeObject<T>(HttpResponseMessage message, bool negTestCase)
        {
            var content = message.Content.ReadAsStringAsync().Result;

            if (message.IsSuccessStatusCode)
            {
                object returnValue = default(T);
                if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
                {
                    returnValue = Convert.ChangeType(content, typeof(T));
                }
                else
                {
                    returnValue = JsonConvert.DeserializeObject<T>(content);
                }


                return returnValue;
            }
            else
            {
                object returnValue = default(T);
                if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
                {
                    returnValue = Convert.ChangeType(content, typeof(T));
                }
                else
                {
                    returnValue = JsonConvert.DeserializeObject<T>(content);
                }

                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, "Request failed.");
                WriteToFile(content, "Response");

                // _writer.WriteLine("Request failed. Response:");
                // _writer.WriteLine(content);              
                return content;
            }



        }

        private object DeserializeObject<T>(HttpResponseMessage message)
        {
            var content = message.Content.ReadAsStringAsync().Result;
            if (message.IsSuccessStatusCode)
            {
                object returnValue = default(T);
                if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
                {
                    returnValue = Convert.ChangeType(content, typeof(T));
                }
                else
                {
                    returnValue = JsonConvert.DeserializeObject<T>(content);
                }
                //ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Response.");
                WriteToFile(content, "Response");

                return returnValue;
            }
            else
            {
                object returnValue = default(T);
                if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
                {
                    returnValue = Convert.ChangeType(content, typeof(T));
                }
                else
                {
                    returnValue = JsonConvert.DeserializeObject<T>(content);
                }

                ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, "Request failed.");
                WriteToFile(content, "Response");

                // _writer.WriteLine("Request failed. Response:");
                // _writer.WriteLine(content);


                return null;

            }

        }

        public static StringContent PayloadToContent(object payload)
        {
            var con = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        }

        public static string PayloadToString(object payload)
        {
            return JsonConvert.SerializeObject(payload, Formatting.Indented);
        }

        public static StringContent StringToContent(string payload)
        {
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }

        public static StringContent StringToContentXML(string payload)
        {
            return new StringContent(payload, Encoding.UTF8, "application/xml");
        }

        public void WriteToFile(string content, string label,string fileEXT = ".json")
        {
            var filenamereq = _random.RandomString() + fileEXT;
            File.WriteAllText(Path.Combine(_writer.Path, filenamereq), content);          
            //_writer.WriteLine("<a href=\"" + filenamereq + "\">" + label + "</a>");
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Error, "<a href=\"" + filenamereq + "\">" + label + "</a>");
        }

        public  T XmlDeserialize<T>(string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(toDeserialize))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        public  string XmlSerialize<T>( T toSerialize)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("load", "http://com.pls.load/loadService_30");
            namespaces.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            namespaces.Add("AUTHENTICATION", "ns");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriterUtf8 textWriter = new StringWriterUtf8())
            {
                xmlSerializer.Serialize(textWriter, toSerialize, namespaces);
                return textWriter.ToString();
            }
        }


        public  string CallWebService(string url, string action, string xml, Dictionary<string, string> headers = null)
        {
            // ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; };

            var envelope = CreateSoapEnvelope(xml);
            var request = CreateWebRequest(url, action, headers);
            ExtentTestManager.GetTest().Log(AventStack.ExtentReports.Status.Info, "Sending POST request");
            InsertSoapEnvelopeIntoWebRequest(envelope, request);
            WriteToFile(xml, "Request",".xml");
            var result = request.BeginGetResponse(null, null);
            result.AsyncWaitHandle.WaitOne();

            using (var response = request.EndGetResponse(result))
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private static XmlDocument CreateSoapEnvelope(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            return document;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action, Dictionary<string, string> headers)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Headers.Add("SOAPAction", action);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml, text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
            request.Method = "POST";
            //request.Date =;
            return request;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument document, HttpWebRequest request)
        {
            using (var stream = request.GetRequestStream())
            {
                document.Save(stream);
            }
        }


        public void Dispose()
        {
            _client.Dispose();
        }
    }

   



}
