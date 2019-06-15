using odd.web.Data.Database;
using odd.web.DTOs.TeamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Services
{
    public class TeamServices : ITeamServices
    {
        public AppDBContext _context;
        public TeamServices(AppDBContext context)
        {
            _context = context;
        }

        public void CreateTeam(CreateTeam dto)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<QueryTeam> QueryTeams()
        {
            return _context.Teams.AsQueryable().Select(x => new QueryTeam { AwayTeam = x.AwayTeam, HomeTeam = x.HomeTeam, Id = x.Id });
        }

        public void UpdateTeam(UpdateTeam dto)
        {
            throw new NotImplementedException();
        }
    }
}
