using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI
{
    public class CustSearchReq
    {
        public int id { get; set; }
        public string modifier { get; set; }
        public string value { get; set; }
        public string condition { get; set; }
        public string country { get; set; }
        public int index { get; set; }
        public object name { get; set; }
        public string shipperId { get; set; }
    }
}
