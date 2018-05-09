using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class StudentRepository: GeneralRepository<Student>
    {
        private OlympiadContext _context;
        public StudentRepository(OlympiadContext context)
        {
            _context = context;
        }

        public override IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(x => x.Department);
        }

        public override void Create(Student item)
        {
            _context.Students.Add(item);
        }

        public override Student Get(int? id)
        {
            return _context.Students.Find(id);
        }

        public override void Delete(int id)
        {
            Student item = _context.Students.Find(id);
            if (item != null)
                _context.Students.Remove(item);
        }
    }
}