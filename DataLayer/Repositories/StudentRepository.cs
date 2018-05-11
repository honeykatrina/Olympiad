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
            Student dbEntity = _context.Students.Find(item.StudentID);
            if (dbEntity != null)
            {
                dbEntity.StudentName = item.StudentName;
                dbEntity.StudentSurname = item.StudentSurname;
                dbEntity.StudentPatronymic = item.StudentPatronymic;
                dbEntity.Course = item.Course;
                dbEntity.Group = item.Group;
                dbEntity.Specialty = item.Specialty;
                dbEntity.DepartmentId = item.DepartmentId;
            }
            _context.SaveChanges();
        }
    }
}