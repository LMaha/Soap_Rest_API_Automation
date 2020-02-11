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
    public class PLSLogin : IDisposable
    {
        private HttpClient _client;

        public PLSLogin(IDictionary<string, string> headers)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(URLs.TMS_Login)
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

        public AuthResponse GetToken(string username, string password)
        {
            //String Authentication = Convert.ToBase64String(Encoding.ASCII.GetBytes("" + username + "" + ":" + "" + password + ""));
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("username", username);
            pairs.Add("password", password);
            pairs.Add("grant_type", "password");
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);
            var result = _client.PostAsync("user/api/user-rest/user/oauth/token", formContent).Result;
            var content1 = result.Content.ReadAsStringAsync().Result;
            AuthResponse returnValue = JsonConvert.DeserializeObject<AuthResponse>(content1);
            return returnValue;
        }

      

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
