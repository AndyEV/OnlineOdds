using System.ComponentModel.DataAnnotations;

namespace odd.web.DTOs.TeamDTOs
{
    public class CreateTeam
    {
        [StringLength(maximumLength: 50)]
        public string HomeTeam { get; set; }

        [StringLength(maximumLength: 50)]
        public string AwayTeam { get; set; }
    }
}
