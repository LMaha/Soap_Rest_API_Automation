using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace SharedAPIFramework
{
    public class GoShipLogin : IDisposable
    {
        private HttpClient _client;

        public GoShipLogin(IDictionary<string, string> headers)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(URLs.GoShip_Login)
            };
            SetHeaders(headers);
        }

        public void SetHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public GoShipAuthResponse GetToken(string username, string password)
        {
               
            var result= _client.PostAsync( "auth/login", null).Result;
            var content1 = result.Content.ReadAsStringAsync().Result;
            GoShipAuthResponse returnValue  = JsonConvert.DeserializeObject<GoShipAuthResponse>(content1);         
            return returnValue;
        }

      

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
