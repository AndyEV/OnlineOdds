using odd.web.DTOs.TeamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Services
{
    public interface ITeamServices
    {
        IQueryable<QueryTeam> QueryTeams();

        void CreateTeam(CreateTeam dto); 

        void UpdateTeam(UpdateTeam dto);

        void DeleteTeam(Guid id);

    }
}
