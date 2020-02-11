using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SharedAPIFramework
{
    public static class URLs
    {
        public static readonly string TMS_Login = ConfigurationManager.AppSettings["LOGIN_URL"];
        public static readonly string Load_Lookup = ConfigurationManager.AppSettings["LOGIN_URL"] + "load/api/load-rest/";
        public static readonly string Customer = ConfigurationManager.AppSettings["LOGIN_URL"] + "customer/api/customer-rest/";
        public static readonly string ftlQuote = ConfigurationManager.AppSettings["LOGIN_URL"] + "quote/api/quotedetails/";
        public static readonly string MileageSVS = ConfigurationManager.AppSettings["Mileage_URL"];
        public static readonly string GoShip_Login = ConfigurationManager.AppSettings["GoShip_Login"];
        public static readonly string CommodityRest = ConfigurationManager.AppSettings["LOGIN_URL"] + "tenant-rest/api/";
        public static readonly string ltlQuote = ConfigurationManager.AppSettings["LOGIN_URL"] + "ltl-lifecycle/api/";
        public static readonly string PayFabric = "https://sandbox.payfabric.com/";
    }
}
