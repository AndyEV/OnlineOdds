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

        public static Odd CreateOddComand(CreateOdd domain) => new Odd { TeamId = domain.TeamId, HomeOdd = domain.HomeOdd, DrawOdd = domain.DrawOdd, AwayOdd = domain.AwayOdd };
        
    }
}
