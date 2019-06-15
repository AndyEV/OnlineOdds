using odd.web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odd.web.Services
{
    public interface IOddServices
    {
        IQueryable<ClientQuery> ClientQueryOdds();
        IQueryable<ClientQuery> AdminQueryOdds(Guid? id);

        void CreateOddAndTeam(CreateOdd dto);

        void CreateOdd(CreateOdd dto);

        void UpdateOdd(UpdateOdd dto);

        void DeleteOdd(Guid id);
    }
}
