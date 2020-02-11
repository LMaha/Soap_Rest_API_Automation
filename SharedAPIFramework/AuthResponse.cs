using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedAPIFramework
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public int expires_in { get; set; }
        public int ID { get; set; }
        public string NAME { get; set; }
        public string jti { get; set; }

    }
}
