﻿using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class OlympiadStudentService : IService<OlympiadStudentDTO>
    {
        private IUnitOfWork _database { get; set; }

        public OlympiadStudentService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(OlympiadStudentDTO item)
        {
            OlympiadStudent olympiadStudent = new OlympiadStudent
            {
                OlympiadStudentID = item.OlympiadStudentID,
                StudentID = item.StudentID,
                OlympiadID = item.OlympiadID,
                StudentPlace = item.StudentPlace,
                InstructorID = item.InstructorID,
                Prize = item.Prize
            };

            _database.OlympiadStudents.Create(olympiadStudent);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            OlympiadStudent itemToDelete = new OlympiadStudent() { OlympiadStudentID = id };
            _database.OlympiadStudents.Delete(itemToDelete.OlympiadStudentID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public OlympiadStudentDTO GetItem(int? id)
        {
            OlympiadStudent olympiadStudent = _database.OlympiadStudents.Get(id);
            return new OlympiadStudentDTO
            {
                OlympiadStudentID = olympiadStudent.OlympiadStudentID,
                StudentID = olympiadStudent.StudentID,
                OlympiadID = olympiadStudent.OlympiadID,
                StudentPlace = olympiadStudent.StudentPlace,
                InstructorID = olympiadStudent.InstructorID,
                Prize = olympiadStudent.Prize
            };
        }

        public IEnumerable<OlympiadStudentDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<OlympiadStudent>, List<OlympiadStudentDTO>>(_database.OlympiadStudents.GetAll());
        }

        public void UpdateItem(OlympiadStudentDTO item)
        {
            OlympiadStudent olympiadStudent = new OlympiadStudent
            {
                OlympiadStudentID = item.OlympiadStudentID,
                StudentID = item.StudentID,
                OlympiadID = item.OlympiadID,
                StudentPlace = item.StudentPlace,
                InstructorID = item.InstructorID,
                Prize = item.Prize
            };
            _database.OlympiadStudents.Update(olympiadStudent);
            _database.Save();
        }
    }
}