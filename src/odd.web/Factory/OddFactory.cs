using odd.web.Data.Domians;
using odd.web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Factory
{
    public class OddFactory
    {

        public static Odd CreateOddComand(CreateOdd dto) => new Odd { TeamId = dto.TeamId, HomeOdd = dto.HomeOdd, DrawOdd = dto.DrawOdd, AwayOdd = dto.AwayOdd, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        public static Odd UpdateOddComand(UpdateOdd dto) => new Odd {  TeamId = dto.TeamId, HomeOdd = dto.HomeOdd, DrawOdd = dto.DrawOdd, AwayOdd = dto.AwayOdd, UpdatedAt = DateTime.Now };
        
    }
}
