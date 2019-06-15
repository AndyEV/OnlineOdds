using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.DTOs
{
    public class UpdateOdd
    {
        public decimal HomeOdd { get; set; }
        public decimal DrawOdd { get; set; }
        public decimal AwayOdd { get; set; }


        // Entity Mapping
        public Guid TeamId { get; set; }
    }
}
