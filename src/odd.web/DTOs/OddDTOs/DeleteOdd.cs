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
    }
}
