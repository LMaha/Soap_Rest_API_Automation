using EDI_soapAPI.Entities.EDIEntities;
using EDI_soapAPI.Entities.ExceptionEntities;
using EDI_soapAPI.Entities.LoadRestResponse;
using SharedAPIFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI
{
    public class LoadRestSvc : IDisposable
    {
        private Http _http;
        private RandomHelper _random;

        public LoadRestSvc(IDictionary<string, string> headers, RandomHelper random, Writer writer)
        {
            _http = new Http(URLs.Load_Lookup, headers, new List<string>(), writer, random);
            _random = random;
        }    

        public LoadSrRes GetLoad(List<CustSearchReq>ldReq)
        {
            return _http.Post<LoadSrRes>("api/loads/board/query-builder/?&page=1&size=50&sortColumn=&sortOrder=", ldReq);
        }

        public LoadsWithIssues GetLoadException()
        {
            return _http.Get<LoadsWithIssues>("api/edi/load/issues/?page=1&size=10");
        }

        public CleExpRes ClearExceptions(CleExpReq clEx)
        {
            return _http.Put<CleExpRes>("api/edi/load/correct/?", clEx);
        }

        public EdiStageRes GetEDIStgedLoads()
        {
            return _http.Get<EdiStageRes>("api/edi/load/staging/?page=1&size=10");
        }

        public void Dispose()
        {
            _http.Dispose();
        }
    }
}
