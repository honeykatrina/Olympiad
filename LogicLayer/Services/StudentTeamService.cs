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
    public class StudentTeamService : IService<StudentTeamDTO>
    {
        private IUnitOfWork _database { get; set; }

        public StudentTeamService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(StudentTeamDTO item)
        {
            StudentTeam studentTeam = new StudentTeam
            {
                StudentTeamID = item.StudentTeamID,
                StudentID = item.StudentID,
                TeamID = item.TeamID
            };

            _database.StudentTeams.Create(studentTeam);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            StudentTeam itemToDelete = new StudentTeam() { StudentTeamID = id };
            _database.StudentTeams.Delete(itemToDelete.StudentTeamID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public StudentTeamDTO GetItem(int? id)
        {
            StudentTeam studentTeam = _database.StudentTeams.Get(id);
            return new StudentTeamDTO
            {
                StudentID = studentTeam.StudentID,
                TeamID = studentTeam.TeamID,
                StudentTeamID = studentTeam.StudentTeamID
            };
        }

        public IEnumerable<StudentTeamDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<StudentTeam>, List<StudentTeamDTO>>(_database.StudentTeams.GetAll());
        }

        public void UpdateItem(StudentTeamDTO item)
        {
            StudentTeam studentTeam = new StudentTeam
            {
                StudentID = item.StudentID,
                TeamID = item.TeamID
            };
            _database.StudentTeams.Update(studentTeam);
            _database.Save();
        }
    }
}