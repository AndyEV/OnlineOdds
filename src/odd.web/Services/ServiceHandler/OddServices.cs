﻿using System;
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

        public IQueryable<AdminQuery> AdminQueryOdds(Guid? id)
        {
            if(id != null)
                return _context.Odds.Where(y => y.TeamId == id).AsQueryable().Include(x => x.Team).Select(x => new AdminQuery { HomeOdd = x.HomeOdd, DrawOdd = x.DrawOdd, AwayOdd = x.AwayOdd, HomeTeam = x.Team.HomeTeam, AwayTeam = x.Team.AwayTeam, LastUpdated = x.UpdatedAt.ToString("dddd, dd MMMM yyyy") });

            return _context.Odds.AsQueryable().Include(x => x.Team).Select(x => new AdminQuery { Id = x.Id, TeamId = x.TeamId, HomeOdd = x.HomeOdd, DrawOdd = x.DrawOdd, AwayOdd = x.AwayOdd, HomeTeam = x.Team.HomeTeam, AwayTeam = x.Team.AwayTeam, LastUpdated = x.UpdatedAt.ToString("dddd, dd MMMM yyyy") });
        }

        public IQueryable<ClientQuery> ClientQueryOdds()
        {
            return _context.Odds.AsQueryable().Include(x => x.Team).Select(x => new ClientQuery { HomeOdd = x.HomeOdd, DrawOdd = x.DrawOdd, AwayOdd = x.AwayOdd, HomeTeam = x.Team.HomeTeam, AwayTeam = x.Team.AwayTeam, LastUpdated = x.UpdatedAt.ToString("dddd, dd MMMM yyyy") });
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

        public bool DeleteOdd(Guid id)
        {
            var _entity = _context.Odds.Find(id);
            if (_entity == null)
            {
                return false;
            }

            _context.Odds.Remove(_entity);
            _context.SaveChanges();

            return true;
        }

        public void UpdateOdd(UpdateOdd dto)
        {
            var _entity = _context.Odds.Find(dto.Id);
            if (_entity == null)
                return;

            _entity.HomeOdd = dto.HomeOdd;
            _entity.AwayOdd = dto.AwayOdd;
            _entity.DrawOdd = dto.DrawOdd;
            _entity.Id = dto.Id;

            _context.Odds.Update(_entity);
            _context.SaveChanges();
        }

        public SingleQuery SingleOdd(Guid id)
        {
            var _ent = _context.Odds.Include(x => x.Team).Where(x => x.Id == id).FirstOrDefault();
            var dto = new SingleQuery () { HomeTeam = _ent.Team.HomeTeam, AwayTeam = _ent.Team.AwayTeam, TeamId = _ent.TeamId, HomeOdd = _ent.HomeOdd, DrawOdd = _ent.DrawOdd, AwayOdd = _ent.AwayOdd, LastUpdated = _ent.UpdatedAt.ToString("dddd, dd MMMM yyyy") };
            return dto;
        }
    }
}
