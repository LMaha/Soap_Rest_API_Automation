using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Net.Http;

namespace SharedAPIFramework
{
    public class BaseTest
    {

        private HttpClient _client;
         

        public AuthResponse GetToken(string username, string password)
        {
            using (var tmsLogin = new PLSLogin
                    (
                        new Dictionary<string, string>()
                            {
                                { "Authorization", "basic dXNlci13ZWI6TWFZemtTam1relBDNTdM" }
                               
                            }
                        )
                  )
            {
                AuthResponse authResponse = tmsLogin.GetToken(username, password);
                return authResponse;

            }

        }

        public GoShipAuthResponse GetGoShipToken(string username, string password)
        {
            //string Authentication = Convert.ToBase64String(Encoding.ASCII.GetBytes("" + username + "" + ":" + "" + password + ""));
            using (var goShipLogin = new GoShipLogin
                    (
                        new Dictionary<string, string>()
                            {
                                { "Authorization", "Basic "+ Convert.ToBase64String(Encoding.ASCII.GetBytes("" + username + "" + ":" + "" + password + ""))}
                            
                            }
                        )
                  )
            {
                GoShipAuthResponse authResponse = goShipLogin.GetToken(username, password);
                return authResponse;

            }

        }

        public IEnumerable<string> GetCookies(string username, string password)
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(URLs.GoShip_Login)
            };

            Dictionary<string, string> pairs = new Dictionary<string, string>();
            pairs.Add("email", username);
            pairs.Add("password", password);         
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(pairs);          
            var result = _client.PostAsync("login", formContent).Result;   
            return result.Headers.First(h => h.Key == "Set-Cookie").Value;
        }


    }
}
