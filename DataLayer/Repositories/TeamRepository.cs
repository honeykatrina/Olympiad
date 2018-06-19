using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class TeamRepository: IRepository<Team>
    {
        private OlympiadContext _context;
        public TeamRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams;
        }

        public void Create(Team item)
        {
            _context.Teams.Add(item);
            _context.SaveChanges();
        }

        public Team Get(int? id)
        {
            return _context.Teams.Find(id);
        }

        public void Delete(int id)
        {
            Team item = _context.Teams.Find(id);
            if (item != null)
                _context.Teams.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Team item)
        {
            Team dbTeam = _context.Teams.Find(item.TeamID);
            if (dbTeam != null)
            {
                dbTeam.TeamName = item.TeamName;
            }
            _context.SaveChanges();
        }
    }
}