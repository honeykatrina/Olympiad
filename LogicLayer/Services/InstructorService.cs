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
    public class InstructorService : IService<InstructorDTO>
    {
        private IUnitOfWork _database { get; set; }

        public InstructorService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(InstructorDTO item)
        {
            Instructor instructor = new Instructor
            {                
                InstructorID = item.InstructorID,
                InstructorName = item.InstructorName,
                InstructorSurname = item.InstructorSurname,
                InstructorPatronymic = item.InstructorPatronymic,
                InstructorTitle = item.InstructorTitle,
                InstructorDegree = item.InstructorDegree,
                InstructorPosition=item.InstructorPosition,
                DepartmentId = item.DepartmentId
            };

            _database.Instructors.Create(instructor);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            Instructor instructor = new Instructor() { InstructorID = id };
            _database.Instructors.Delete(instructor.InstructorID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public InstructorDTO GetItem(int? id)
        {
            Instructor instructor = _database.Instructors.Get(id);
            //return Mapper.Map<Student, StudentDTO>(student);
            return new InstructorDTO
            {
                InstructorID = instructor.InstructorID,
                InstructorName = instructor.InstructorName,
                InstructorSurname = instructor.InstructorSurname,
                InstructorPatronymic = instructor.InstructorPatronymic,
                InstructorTitle = instructor.InstructorTitle,
                InstructorDegree = instructor.InstructorDegree,
                InstructorPosition = instructor.InstructorPosition,
                DepartmentId = instructor.DepartmentId
            };
        }

        public IEnumerable<InstructorDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<Instructor>, List<InstructorDTO>>(_database.Instructors.GetAll());
        }

        public void UpdateItem(InstructorDTO item) //???
        {
            Instructor instructor = _database.Instructors.Get(item.InstructorID);
            _database.Instructors.Update(instructor);
        }
    }
}