using DataLayer.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Interfaces;
using DataLayer.Models;
using AutoMapper;

namespace LogicLayer.Services
{
    public class StudentService : IService<StudentDTO> // добавить проверки на сущетсвование элемента
    {
        private IUnitOfWork _database { get; set; }

        public StudentService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(StudentDTO item)
        {
            Student student = new Student
            {
                StudentID = item.StudentID,
                StudentName = item.StudentName,
                StudentSurname = item.StudentSurname,
                StudentPatronymic = item.StudentPatronymic,
                Course = item.Course,
                Group = item.Group,
                Specialty = item.Specialty,
                DepartmentId = item.DepartmentId
            };

            _database.Students.Create(student);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            Student studentToDelete = new Student() { StudentID = id };
            _database.Students.Delete(studentToDelete.StudentID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public StudentDTO GetItem(int? id)
        {
            Student student = _database.Students.Get(id);
            //return Mapper.Map<Student, StudentDTO>(student);
            return new StudentDTO
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                StudentSurname = student.StudentSurname,
                StudentPatronymic = student.StudentPatronymic,
                Course = student.Course,
                Specialty = student.Specialty,
                Group = student.Group,
                DepartmentId = student.DepartmentId
            };
        }

        public IEnumerable<StudentDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(_database.Students.GetAll());
        }

        public void UpdateItem(StudentDTO item) //???
        {
            Student student = new Student
            {
                StudentID = item.StudentID,
                StudentName = item.StudentName,
                StudentSurname = item.StudentSurname,
                StudentPatronymic = item.StudentPatronymic,
                Course = item.Course,
                Group = item.Group,
                Specialty = item.Specialty,
                DepartmentId = item.DepartmentId
            };
            //Student student = _database.Students.Get(item.StudentID);
            _database.Students.Update(student);
            _database.Save();
        }
    }
}