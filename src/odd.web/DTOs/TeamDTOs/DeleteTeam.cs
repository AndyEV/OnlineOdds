using System;
using System.ComponentModel.DataAnnotations;

namespace odd.web.DTOs.TeamDTOs
{
    public class DeleteTeam
    {
        [Required]
        public Guid Id { get; set; }
    }
}
