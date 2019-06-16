using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.DTOs
{
    public class DeleteOdd
    {
        [Required]
        public Guid Id { get; set; }

        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public decimal HomeOdd { get; set; }
        public decimal DrawOdd { get; set; }
        public decimal AwayOdd { get; set; }
    }
}
