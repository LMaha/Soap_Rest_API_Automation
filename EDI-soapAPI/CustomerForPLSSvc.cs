using EDI_soapAPI.Entities;
using SharedAPIFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI
{
    public class CustomerForPLSSvc : IDisposable
    {
        private Http _http;
        private RandomHelper _random;

        public CustomerForPLSSvc(IDictionary<string, string> headers, RandomHelper random, Writer writer)
        {
            _http = new Http(URLs.Customer, headers, new List<string>(), writer, random);
            _random = random;
        }

        public CustResponse CreateCustomer(CreateCustReq customer)
        {
            return _http.Post<CustResponse>("api/customer", customer);

        }

        public UpdCustRes UpdateCustomer(int custId, UpdCustomer customer)
        {
            return _http.Put<UpdCustRes>("api/customer/"+custId,customer);
        }

        //public CreateNewGSCustomerResponse GetGSCustomer(int? customerId)
        //{
        //    return _http.Get<CreateNewGSCustomerResponse>("api/gs-customer/" + customerId);

        //}

        //public CreateNewGSCustomerResponse UpdateGSCustomer(UpdateCustomer customer)
        //{
        //    return _http.Put<CreateNewGSCustomerResponse>("api/gs-customer/" + Variables.CustomerId, customer);

        //}

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}
