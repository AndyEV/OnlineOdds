﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.DTOs
{
    public class ClientQuery
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeOdd { get; set; }
        public decimal DrawOdd { get; set; }
        public decimal AwayOdd { get; set; }
        public string LastUpdated { get; set; }


    }
}
