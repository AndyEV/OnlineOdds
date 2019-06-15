using odd.web.Data.Domians;
using odd.web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Factory
{
    public class TeamFactory
    {
        public static Team CreateTeam(CreateOdd dto)
        {
            return new Team
            {
                Id = Guid.NewGuid(),
                HomeTeam = dto.HomeTeam,
                AwayTeam = dto.AwayTeam,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
    }
}
