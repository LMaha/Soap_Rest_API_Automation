using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.CustResponse
{
    public class CustomerNote
    {
        public CreatedBy createdBy { get; set; }
        public string createdDate { get; set; }
        public ModifiedBy modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public int id { get; set; }
        public NoteTypes noteTypes { get; set; }
        public object notesDesc { get; set; }
        public int customerId { get; set; }
    }
}
