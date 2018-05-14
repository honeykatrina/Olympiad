using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class InstructorRepository: IRepository<Instructor>
    {
        private OlympiadContext _context;
        public InstructorRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors;
        }

        public void Create(Instructor item)
        {
            _context.Instructors.Add(item);
            _context.SaveChanges();
        }

        public Instructor Get(int? id)
        {
            return _context.Instructors.Find(id);
        }

        public void Delete(int id)
        {
            Instructor item = _context.Instructors.Find(id);
            if (item != null)
                _context.Instructors.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Instructor item)
        {
            Instructor dbInstructor = _context.Instructors.Find(item.InstructorID);
            if (dbInstructor != null)
            {
                dbInstructor.InstructorName = item.InstructorName;
                dbInstructor.InstructorSurname = item.InstructorSurname;
                dbInstructor.InstructorPatronymic = item.InstructorPatronymic;
                dbInstructor.InstructorTitle = item.InstructorTitle;
                dbInstructor.InstructorDegree = item.InstructorDegree;
                dbInstructor.InstructorPosition = item.InstructorPosition;
                dbInstructor.DepartmentId = item.DepartmentId;
            }
            _context.SaveChanges();
        }
    }
}