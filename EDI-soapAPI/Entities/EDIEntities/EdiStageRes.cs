﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_soapAPI.Entities.EDIEntities
{
    public class EdiStageRes
    {
     
            public Headers headers { get; set; }
            public Body body { get; set; }
            public string statusCode { get; set; }
            public int statusCodeValue { get; set; }
        
    }
}
