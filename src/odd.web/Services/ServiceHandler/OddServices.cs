using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using odd.web.Data.Database;
using odd.web.DTOs;
using odd.web.Factory;

namespace odd.web.Services
{
    public class OddServices : IOddServices
    {
        public AppDBContext _context;
        public OddServices(AppDBContext context)
        {
            _context = context;
        }

        public IQueryable<ClientQuery> AdminQueryOdds(Guid? id)
        {
            return _context.Odds.Where(y => y.TeamId == id).AsQueryable().Include(x => x.Team).Select(x => new ClientQuery { HomeOdd = x.HomeOdd, DrawOdd = x.DrawOdd, AwayOdd = x.AwayOdd, HomeTeam = x.Team.HomeTeam, AwayTeam = x.Team.AwayTeam, LastUpdated = x.UpdatedAt.ToString("dddd, dd MMMM yyyy") });

        }

        public IQueryable<ClientQuery> ClientQueryOdds()
        {
            return _context.Odds.AsQueryable().Include(x => x.Team).Select(x => new ClientQuery { TeamId = x.TeamId, HomeOdd = x.HomeOdd, DrawOdd = x.DrawOdd, AwayOdd = x.AwayOdd, HomeTeam = x.Team.HomeTeam, AwayTeam = x.Team.AwayTeam, LastUpdated = x.UpdatedAt.ToString("dddd, dd MMMM yyyy") });
        }

        public void CreateOddAndTeam(CreateOdd dto)
        {
            if (dto.TeamId == Guid.Empty)
            {
                var _obj = TeamFactory.CreateTeam(dto);
                dto.TeamId = _obj.Id;
                _context.Teams.Add(_obj);
                _context.Odds.Add(OddFactory.CreateOddComand(dto));
            }
            else
              _context.Odds.Add(OddFactory.CreateOddComand(dto));

            _context.SaveChanges();
        }

        public void CreateOdd(CreateOdd dto)
        {
            _context.Odds.Add(OddFactory.CreateOddComand(dto));
            _context.SaveChanges();
        }

        public void DeleteOdd(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOdd(UpdateOdd dto)
        {
            throw new NotImplementedException();
        }
    }
}
