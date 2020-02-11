using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.CustResponse
{
    public class GlCoding
    {
        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public PlsDivision plsDivision { get; set; }
        public PlsOffice plsOffice { get; set; }
    }
}
