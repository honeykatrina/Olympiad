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
    public class OlympiadStudentRepository : IRepository<OlympiadStudent>
    {
        private OlympiadContext _context;
        public OlympiadStudentRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<OlympiadStudent> GetAll()
        {
            return _context.OlympiadStudents.Include(x => x.Olympiad).Include(x => x.Student).Include(x => x.Instructor).ToList();
        }

        public void Create(OlympiadStudent item)
        {
            _context.OlympiadStudents.Add(item);
            _context.SaveChanges();
        }

        public OlympiadStudent Get(int? id)
        {
            return _context.OlympiadStudents.Find(id);
        }

        public void Delete(int id)
        {
            OlympiadStudent item = _context.OlympiadStudents.Find(id);
            if (item != null)
                _context.OlympiadStudents.Remove(item);
            _context.SaveChanges();
        }

        public void Update(OlympiadStudent item)
        {
            OlympiadStudent dbOlympiadStudent = _context.OlympiadStudents.Find(item.OlympiadStudentID);
            if (dbOlympiadStudent != null)
            {
                dbOlympiadStudent.StudentID = item.StudentID;
                dbOlympiadStudent.InstructorID = item.InstructorID;
                dbOlympiadStudent.OlympiadID= item.OlympiadID;
                dbOlympiadStudent.StudentPlace = item.StudentPlace;
                dbOlympiadStudent.Prize = item.Prize;
            }
            _context.SaveChanges();
        }
    }
}