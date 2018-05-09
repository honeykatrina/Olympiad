using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Interfaces;
using System.Data.Entity;

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
        }

        public void Update(Team item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}