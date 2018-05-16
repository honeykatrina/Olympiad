using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class StudentTeamRepository : IRepository<StudentTeam>
    {
        private OlympiadContext _context;
        public StudentTeamRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentTeam> GetAll()
        {
            return _context.StudentTeams.Include(x => x.Team).Include(x => x.Student).ToList();
        }

        public void Create(StudentTeam item)
        {
            _context.StudentTeams.Add(item);
            _context.SaveChanges();
        }

        public StudentTeam Get(int? id)
        {
            return _context.StudentTeams.Find(id);
        }

        public void Delete(int id)
        {
            StudentTeam item = _context.StudentTeams.Find(id);
            if (item != null)
                _context.StudentTeams.Remove(item);
            _context.SaveChanges();
        }

        public void Update(StudentTeam item)
        {
            StudentTeam dbStudentTeam = _context.StudentTeams.Find(item.StudentTeamID);
            if (dbStudentTeam != null)
            {
                dbStudentTeam.TeamID = item.TeamID;
                dbStudentTeam.StudentID = item.StudentID;
            }
            _context.SaveChanges();
        }
    }
}