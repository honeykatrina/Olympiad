using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class StudentRepository: IRepository<Student>
    {
        private OlympiadContext _context;
        public StudentRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.Include(x => x.Department);
        }

        public void Create(Student item)
        {
            _context.Students.Add(item);
            _context.SaveChanges();
        }

        public Student Get(int? id)
        {
            return _context.Students.Find(id);
        }

        public void Delete(int id)
        {
            Student item = _context.Students.Find(id);
            if (item != null)
                _context.Students.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Student item)
        {
            Student dbStudent = _context.Students.Find(item.StudentID);
            if (dbStudent != null)
            {
                dbStudent.StudentName = item.StudentName;
                dbStudent.StudentSurname = item.StudentSurname;
                dbStudent.StudentPatronymic = item.StudentPatronymic;
                dbStudent.Course = item.Course;
                dbStudent.Group = item.Group;
                dbStudent.Specialty = item.Specialty;
                dbStudent.DepartmentId = item.DepartmentId;
            }
            _context.SaveChanges();
        }
    }
}