using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.DTOs
{
    public class AdminQuery
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeOdd { get; }
        public decimal DrawOdd { get; }
        public decimal AwayOdd { get; }


        // Entity Mapping
        public Guid TeamId { get; set; }
    }
}
