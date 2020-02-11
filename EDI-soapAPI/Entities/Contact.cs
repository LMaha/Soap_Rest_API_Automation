using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities
{
    public class Contact
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactPhoneNum { get; set; }
        public string emailId { get; set; }
        public bool? active { get; set; }



        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public object contactFaxNum { get; set; }
        public object contactRole { get; set; }


    }

}
