using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Data.Domians
{
    public class Team : BaseEntity<Guid>
    {
        public Team()
        {
            Odds = new HashSet<Odd>();
        }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength:50)]
        public string HomeTeam { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 50)]
        public string AwayTeam { get; set; }

        public virtual ICollection<Odd> Odds { get; set; }
    }
}
