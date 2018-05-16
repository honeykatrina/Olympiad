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
    public class OlympiadTeamService : IService<OlympiadTeamDTO>
    {
        private IUnitOfWork _database { get; set; }

        public OlympiadTeamService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(OlympiadTeamDTO item)
        {
            OlympiadTeam olympiadTeam = new OlympiadTeam
            {
                OlympiadTeamID = item.OlympiadTeamID,
                TeamID = item.TeamID,
                OlympiadID = item.OlympiadID,
                TeamPlace = item.TeamPlace,
                InstructorID = item.InstructorID,
                Prize = item.Prize
            };

            _database.OlympiadTeams.Create(olympiadTeam);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            OlympiadTeam itemToDelete = new OlympiadTeam() { OlympiadTeamID = id };
            _database.OlympiadTeams.Delete(itemToDelete.OlympiadTeamID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public OlympiadTeamDTO GetItem(int? id)
        {
            OlympiadTeam olympiadTeam = _database.OlympiadTeams.Get(id);
            return new OlympiadTeamDTO
            {
                OlympiadTeamID = olympiadTeam.OlympiadTeamID,
                TeamID = olympiadTeam.TeamID,
                OlympiadID = olympiadTeam.OlympiadID,
                TeamPlace = olympiadTeam.TeamPlace,
                InstructorID = olympiadTeam.InstructorID,
                Prize = olympiadTeam.Prize
            };
        }

        public IEnumerable<OlympiadTeamDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<OlympiadTeam>, List<OlympiadTeamDTO>>(_database.OlympiadTeams.GetAll());
        }

        public void UpdateItem(OlympiadTeamDTO item)
        {
            OlympiadTeam olympiadTeam = new OlympiadTeam
            {
                OlympiadTeamID = item.OlympiadTeamID,
                TeamID = item.TeamID,
                OlympiadID = item.OlympiadID,
                TeamPlace = item.TeamPlace,
                InstructorID = item.InstructorID,
                Prize = item.Prize
            };
            _database.OlympiadTeams.Update(olympiadTeam);
            _database.Save();
        }
    }
}