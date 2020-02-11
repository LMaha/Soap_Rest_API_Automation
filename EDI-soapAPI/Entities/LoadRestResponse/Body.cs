﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.LoadRestResponse
{
    public class Body
    {
        public int resultSize { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public object loadDetails { get; set; }
        public List<LoadQBDetail> loadQBDetails { get; set; }
    }
}
