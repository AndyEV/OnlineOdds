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
        IQueryable<AdminQuery> AdminQueryOdds(Guid? id);
        SingleQuery SingleOdd(Guid id);

        void CreateOddAndTeam(CreateOdd dto);

        void CreateOdd(CreateOdd dto);

        void UpdateOdd(UpdateOdd dto);

        bool DeleteOdd(Guid id);
    }
}
