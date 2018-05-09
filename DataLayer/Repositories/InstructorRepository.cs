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
        }

        public void Update(Instructor item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}