using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer.Repositories
{
    public class OlympiadTeamRepository : IRepository<OlympiadTeam>
    {
        private OlympiadContext _context;
        public OlympiadTeamRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<OlympiadTeam> GetAll()
        {
            return _context.OlympiadTeams.Include(x => x.Team).Include(x => x.Olympiad).Include(x => x.Instructor).ToList();
        }

        public void Create(OlympiadTeam item)
        {
            _context.OlympiadTeams.Add(item);
            _context.SaveChanges();
        }

        public OlympiadTeam Get(int? id)
        {
            return _context.OlympiadTeams.Find(id);
        }

        public void Delete(int id)
        {
            OlympiadTeam item = _context.OlympiadTeams.Find(id);
            if (item != null)
                _context.OlympiadTeams.Remove(item);
            _context.SaveChanges();
        }

        public void Update(OlympiadTeam item)
        {
            OlympiadTeam dbOlympiadTeam = _context.OlympiadTeams.Find(item.OlympiadTeamID);
            if (dbOlympiadTeam != null)
            {
                dbOlympiadTeam.TeamID = item.TeamID;
                dbOlympiadTeam.InstructorID = item.InstructorID;
                dbOlympiadTeam.OlympiadID= item.OlympiadID;
                dbOlympiadTeam.TeamPlace = item.TeamPlace;
                dbOlympiadTeam.Prize = item.Prize;
            }
            _context.SaveChanges();
        }
    }
}